using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
	public Text levelText;
	public Text scoreText;
	public Text livesText;
	public Text gameOverText;


	private static int lives = 3;
	public static int Lives {
		set { 
			lives = value;
			UpdateLivesText ();
		}
		get { return lives; }
	}

	private static int score = 0;
	public static int Score {
		set { 
			score += value;
			UpdateScoreText ();
		}
		get { return score; }
	}

	private static Text _scoreText;
	private static Text _levelText;
	private static Text _livesText;
	private static Text _gameOverText;
	private static int level = 0;
	public static int Level { get; }

	void Awake(){
		_levelText = levelText;
		_scoreText = scoreText;
		_livesText = livesText;
		_gameOverText = gameOverText;
	}

	void Start(){
		NewGame ();
	}

	public static void NewGame(){
		// Reset player
		// Destroy existing Asteroids
		// Hide Game Over Text
		_gameOverText.enabled = false;
		// Reset score
		Score = 0;
		// Reset Lives
		Lives = 3;
		// Reset level
		level = 0;
		// Start
		NextLevel();
	}

	public static void NextLevel(){
		level++;
		UpdateLevelText ();
		AsteroidSpawner.Spawn (level);
	}

	public static void GameOver(){
		_gameOverText.GetComponent<FadeControl> ().FadeIn ();
	}

	private static void UpdateLevelText (){
		_levelText.text = "Level: " + level;
	}

	private static void UpdateScoreText(){
		_scoreText.text = "Score: " + score;
	}

	private static void UpdateLivesText(){
		_livesText.text = "Lives: " + lives;
	}
}
