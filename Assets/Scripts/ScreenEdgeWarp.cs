using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEdgeWarp : MonoBehaviour {

	public static float Height {
		get { return Camera.main.orthographicSize * 2; }
	}

	public static float Width {
		get { return Height * Screen.width / Screen.height; }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float vertExtent = Camera.main.orthographicSize;    
		float horzExtent = vertExtent * Screen.width / Screen.height;

		if (transform.position.x > horzExtent * 1) {
			transform.position += Vector3.left * horzExtent * 2;
		}
		else if (transform.position.x < -horzExtent * 1){
			transform.position += Vector3.right * horzExtent * 2;
		}

		if (transform.position.z > vertExtent * 1) {
			transform.position += Vector3.back * vertExtent * 2;
		}
		else if (transform.position.z < -vertExtent * 1){
			transform.position += Vector3.forward * vertExtent * 2;
		}
	}
}
