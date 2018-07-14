using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostify : MonoBehaviour {

	private Transform[] ghosts = new Transform[8];

	void Awake(){
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 8; i++) {
			ghosts[i] = Instantiate (transform, transform.position, transform.rotation, transform.parent);
			foreach (Component component in ghosts[i].GetComponents<Component>()) {
				if (!(component is Renderer || component is Transform || component is MeshFilter || component is Collider)) {
					DestroyImmediate (component);
				}
			}
			GhostController gc = ghosts [i].gameObject.AddComponent<GhostController> ();
			gc.Initialize (gameObject);
		}
		PositionGhosts ();
	}

	// Update is called once per frame
	void Update () {
		PositionGhosts ();
	}

	private int[,] ghostPositions = new int[,] {
		{1,0},
		{1,1},
		{0,1},
		{-1,0},
		{-1,-1},
		{0,-1},
		{-1,1},
		{1,-1}
	};

	void PositionGhosts()
	{
		// All ghost ships should have the same rotation as the main ship
		for(int i = 0; i < 8; i++)
		{
			if (ghosts [i] == null)
				continue;
			
			Vector3 ghostPosition = Vector3.zero;
			ghostPosition.x = transform.position.x + ScreenEdgeWarp.Width * ghostPositions[i,0];
			ghostPosition.z = transform.position.z + ScreenEdgeWarp.Height * ghostPositions[i,1];
			ghosts[i].position = ghostPosition;

			ghosts[i].rotation = transform.rotation;
		}
	}

	void OnDestroy(){
		for (int i = 0; i < ghosts.Length; i++) {
			if (ghosts [i] != null)
				Destroy (ghosts [i].gameObject);
		}
	}
}
