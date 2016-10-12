using UnityEngine;
using System.Collections;

public class TargetCursor : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}

	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3 (0, 0, 1),1);
	}
		
}
