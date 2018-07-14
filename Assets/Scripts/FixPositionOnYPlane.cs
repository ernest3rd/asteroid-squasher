using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPositionOnYPlane : MonoBehaviour {

	public float y = 0f;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, y, transform.position.z);
	}
}
