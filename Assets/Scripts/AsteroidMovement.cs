using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {
	public GameObject explosion;
	public float massToScaleRatio = 0.1f;

	private float mass;
	private Rigidbody rb;


	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		if (rb.velocity.magnitude == 0) {
			rb.AddForce (new Vector3(Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f)).normalized * Random.Range(0f, 50f));
		}
		mass = rb.mass;
		UpdateScale ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, 2f);
	}

	void fixedUpdate(){
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, 2f);
	}

	public void Init(){
		rb.mass = Random.Range (4, 5) * 1.0f;
		mass = rb.mass;
		UpdateScale ();
	}

	private void UpdateScale(){
		transform.localScale = transform.localScale.normalized * mass * 0.5f;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Laser")) {
			Destroy (other.gameObject);
			LevelController.Score = Mathf.FloorToInt(mass * 100);
			if (rb && --rb.mass > 1) {
				UpdateScale ();
				for (int i = Random.Range(3,5); i > 0; i--) {
					Instantiate (transform, transform.position, Quaternion.Euler (0, i * 90f, 0), transform.parent);
				}
			}
			GameObject exp = Instantiate (explosion, transform.position+Vector3.up, Quaternion.Euler (Vector3.forward));
			Destroy (exp, 3);
			Destroy (gameObject);
		}
	}
}
