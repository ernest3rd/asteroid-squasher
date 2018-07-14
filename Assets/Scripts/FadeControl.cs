using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FadeIn(){
		Text text = GetComponent<Text> ();
		text.enabled = true;
		text.color = new Color (text.color.r, text.color.g, text.color.b, 0f);
		StartCoroutine(FadeTo(text, 1f, 5f));
		StartCoroutine (ScaleFromTo (transform, 1.5f, 1f, 5f));
	}

	IEnumerator FadeTo(Text text, float target, float duration){
		float alpha = text.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration) {
			Color newColor = new Color (text.color.r, text.color.g, text.color.b, Mathf.Lerp (alpha, target, t));
			text.color = newColor;
			yield return null;
		}
	}

	IEnumerator ScaleFromTo(Transform tf, float start, float end, float duration){
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration) {
			float current = Mathf.Lerp (start, end, t);
			Vector3 newScale = new Vector3 (current, current, current);
			tf.localScale = newScale;
			yield return null;
		}
	}
}
