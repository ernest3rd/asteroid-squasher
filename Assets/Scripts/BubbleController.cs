using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour {


	public float alpha = 1f;
	public float duration = 2f;

	private bool active = true;

	public bool Active {
		get { return active; }
		set { 
			if (value) {
				Enable ();
				StartCoroutine (WaitAndDisableBubble (duration));
			} else {
				Disable ();
			}
		}
	}

	void Awake(){
		Disable ();
	}

	// Use this for initialization
	void Start () {
		
	}

	private void Enable(){
		active = true;
		GetComponent<Collider> ().enabled = true;
		Renderer rndr = GetComponent<Renderer> ();
		Color color = rndr.material.GetColor ("_TintColor");
		rndr.material.SetColor("_TintColor", new Color (color.r, color.g, color.b, alpha));
		rndr.enabled = true;
	}

	private void Disable(){
		active = false;
		GetComponent<Collider> ().enabled = false;
		GetComponent<Renderer> ().enabled = false;
	}

	private IEnumerator WaitAndDisableBubble(float waitTime){
		yield return new WaitForSeconds(waitTime);
		StartCoroutine (FadeOutBubble(duration));
	}

	private IEnumerator FadeOutBubble(float time){
		Color color = GetComponent<MeshRenderer> ().material.GetColor ("_TintColor");
		float _alpha = color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time) {
			Color newColor = new Color (color.r, color.g, color.b, Mathf.Lerp (_alpha, 0, t));
			GetComponent<MeshRenderer>().material.SetColor("_TintColor", newColor);
			yield return null;
		}
		Disable ();
	}
}
