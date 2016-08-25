using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RefneticsField : MonoBehaviour {
	public float refneticsPower = 100.0f;
	public List<GameObject> refneticableObjList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Z)) this.test();
	}

	void OnTriggerStay(Collider col) {
		print(col.gameObject.name+" is staying");
		if (!refneticableObjList.Contains (col.gameObject))
			refneticableObjList.Add (col.gameObject);
	}

	void OnTriggerExit(Collider col) {
		print(col.gameObject.name+" exits");
		if (refneticableObjList.Contains (col.gameObject))
			refneticableObjList.Remove (col.gameObject);
	}

	void test(){
		foreach (GameObject go in refneticableObjList) {
			Vector3 vec3 = (go.transform.position - transform.position).normalized;
			go.GetComponent<Rigidbody>().AddForce(vec3 * refneticsPower, ForceMode.Force);
		}
	}

}
