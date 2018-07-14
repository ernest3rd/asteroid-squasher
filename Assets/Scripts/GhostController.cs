using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {

	private GameObject original;
	private bool visible = true;

	public void Initialize(GameObject o){
		original = o;
	}

	void Update(){
	}
	
	void OnCollisionEnter(Collision collision){
		if(original)
			original.BroadcastMessage ("OnCollisioEnter", collision, SendMessageOptions.DontRequireReceiver);
	}

	void OnCollisionExit(Collision collision){
		if(original)
			original.BroadcastMessage ("OnCollisionExit", collision, SendMessageOptions.DontRequireReceiver);
	}
	void OnCollisionStay(Collision collision){
		if(original)
			original.BroadcastMessage ("OnCollisionStay", collision, SendMessageOptions.DontRequireReceiver);
	}
		
	void OnTriggerEnter(Collider collider){
		if(original)
			original.BroadcastMessage ("OnTriggerEnter", collider, SendMessageOptions.DontRequireReceiver);
	}

	void OnTriggerExit(Collider collider){
		if(original)
			original.BroadcastMessage ("OnTriggerExit", collider, SendMessageOptions.DontRequireReceiver);
	}
	void OnTriggerStay(Collider collider){
		if(original)
			original.BroadcastMessage ("OnTriggerStay", collider, SendMessageOptions.DontRequireReceiver);
	}
}
