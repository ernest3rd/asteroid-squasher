using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour {

	public float timeToLive = 5;

	private float lifeLeft;

	// Use this for initialization
	void Start () {
		lifeLeft = timeToLive;
	}
	
	// Update is called once per frame
	void Update () {
		lifeLeft -= Time.deltaTime;

		if (lifeLeft < 0) {
			Destroy (gameObject);
		}
	}
}
