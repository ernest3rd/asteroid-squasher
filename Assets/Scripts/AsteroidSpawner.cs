using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

	public int numberOfAsteroids = 5;
	public GameObject asteroid_birth;
	private static AsteroidSpawner _this;
	private static GameObject _birth;

	// Use this for initialization
	void Awake () {
		_this = this;
		_birth = asteroid_birth;
	}

	void Update () {
		CountAsteroids ();
	}

	public static void Spawn(int amount){
		for (int i = 0; i < amount; i++) {
			Vector3 pos = new Vector3(
				Random.Range (0f, ScreenEdgeWarp.Width) - ScreenEdgeWarp.Width/2,
				0,
				Random.Range (0, ScreenEdgeWarp.Height) - ScreenEdgeWarp.Height/2
			);
			Instantiate (_birth, pos, Quaternion.Euler(Vector3.up), _this.transform);
		}
	}

	void CountAsteroids(){
		GameObject[] asteroids = GameObject.FindGameObjectsWithTag ("Asteroid");
		//Debug.Log (asteroids.Length);
 		if (asteroids.Length == 0) {
			LevelController.NextLevel ();
		}
	}
}
