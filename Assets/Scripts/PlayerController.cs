using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private bool dead = false;

	private int score = 0;
	private Rigidbody rb;
	private BubbleController bubble;

	public float acceleration = 2f;
	public float maxVelocity = 10f;
	public float turningSpeed = 100f;
	public GameObject laser;
	public GameObject explosion;
	public GameObject engine;
	public GameObject birth_anim;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
		bubble = GetComponentInChildren<BubbleController> ();
	}

	// Use this for initialization
	void Start () {
		Disable ();
		StartCoroutine (Rebirth (3f));
	}
	
	// Update is called once per frame
	void Update () {
		if (dead)
			return;
			
		float rotate = Input.GetAxisRaw ("Horizontal");
		float tilt = 0;

		if (rotate > 0) {
			tilt = -20f;
		} else if (rotate < 0) {
			tilt = 20f;
		} else {
			tilt = 0f;
		}

		transform.Rotate (new Vector3 (0, rotate * turningSpeed * Time.deltaTime, 0));

		if (Input.GetButtonDown ("Fire")) {
			Instantiate (laser, transform.position, transform.rotation);
		}
	}

	void FixedUpdate(){
		if (dead)
			return;
		
		float rotate = Input.GetAxisRaw ("Horizontal");
		float accelerate = Input.GetAxisRaw ("Vertical");

		if (accelerate > 0) {
			rb.AddForce (transform.forward * acceleration * accelerate);
			foreach(Renderer rndr in engine.GetComponentsInChildren<Renderer> ()){
				rndr.enabled = true;
			}
		} else {
			foreach(Renderer rndr in engine.GetComponentsInChildren<Renderer> ()){
				rndr.enabled = false;
			}
		}
	}

	private void Disable(){
		enabled = false;
		foreach(Renderer rndr in engine.GetComponentsInChildren<Renderer> ()){
			rndr.enabled = false;
		}
		gameObject.GetComponent<Renderer> ().enabled = false;
		gameObject.GetComponent<Collider> ().enabled = false;
		rb.velocity = Vector3.zero;
	}

	private void Enable(){
		enabled = true;
		gameObject.GetComponent<Renderer> ().enabled = true;
		gameObject.GetComponent<Collider> ().enabled = true;
	}

	void OnCollisionEnter(Collision collision){
		if (!bubble.Active && collision.gameObject.CompareTag ("Asteroid")) {
			Instantiate (explosion, transform.position, Quaternion.Euler (Vector3.forward));
			Disable ();
			if (LevelController.Lives > 0) {
				LevelController.Lives = LevelController.Lives - 1;
				StartCoroutine (Rebirth(3f));
			} else {
				
				LevelController.GameOver ();
			}
		}
	}

	IEnumerator Rebirth(float waitTime) {
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		transform.rotation = Quaternion.Euler (Vector3.zero);
		transform.position = Vector3.zero;
		Instantiate (birth_anim, transform);
			
		yield return new WaitForSeconds(waitTime);

		rb.AddForce(new Vector3 (Random.Range(-1f,1f), 0, Random.Range(-1f,1f)).normalized * 4);
		bubble.Active = true;
		Enable ();
	}
}
