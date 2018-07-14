using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour {
	private Vector3 rotation;
	private float rotationSpeed;


	// Use this for initialization
	void Start () {
		rotationSpeed = Random.Range (10f, 50f);
		rotation = new Vector3 (Random.Range (0, 360f), Random.Range (0, 360f), Random.Range (0, 360f)).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (rotation * rotationSpeed * Time.deltaTime);
	}
}
