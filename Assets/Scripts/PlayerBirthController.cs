using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBirthController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		StartCoroutine(GiveBirth (3f));
	}

	IEnumerator GiveBirth(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		GetComponent<Renderer> ().enabled = false;
		Destroy (gameObject, 2f);
	}
}
