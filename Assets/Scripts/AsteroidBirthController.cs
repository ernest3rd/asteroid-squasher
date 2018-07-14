using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBirthController : MonoBehaviour {
	public GameObject asteroid;

	// Use this for initialization
	void Start () {
		StartCoroutine(GiveBirth (3f));
	}

	IEnumerator GiveBirth(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		GameObject _asteroid = Instantiate (asteroid, transform.position, transform.rotation, transform.parent);
		_asteroid.GetComponent<AsteroidMovement> ().Init ();
		GetComponent<Renderer> ().enabled = false;
		Destroy (gameObject, 2f);
	}
}
