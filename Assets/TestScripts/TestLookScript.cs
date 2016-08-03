using UnityEngine;
using System.Collections;

public class TestLookScript : MonoBehaviour {
    public GameObject targetObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.LookAt(targetObj.transform);
    }
}
