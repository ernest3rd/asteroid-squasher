using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour {

	public float speed = 4f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		transform.Rotate (new Vector3 (0, Random.Range(-3f, 3f), 0));
		rb.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
