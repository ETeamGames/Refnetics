using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerRefneticsScript : MonoBehaviour {
	public Camera camera;
	public float refneticsSpeed;
	public float rayLimit;

	public List<GameObject> refneticableObjList;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Application.platform == RuntimePlatform.Android ||Application.platform ==  RuntimePlatform.IPhonePlayer)
		{
			phoneClickProc();
		}
		else
		{
			pcClickProc();
		}
	}

	///PC用
	private void pcClickProc()
	{
		if (!Input.GetMouseButtonDown(0)) return;
		//メインカメラ上のマウスカーソルのある位置からRayを飛ばす
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		refnetics(ray.direction);
	}

	///スマホ用
	private void phoneClickProc()
	{
		if (Input.touchCount == 0) return;
		//メインカメラ上のマウスカーソルのある位置からRayを飛ばす
		Ray ray = camera.ScreenPointToRay(Input.GetTouch(1).position);
		RaycastHit hit;

		refnetics(ray.direction);
	}

	/// <summary>
	/// Refnetics範囲内にあるオブジェクトをクリック方向に反射
	/// </summary>
	/// <param name = "direction"> クリック方向.</param>
	private void refnetics(Vector3 direction)
	{
		foreach (GameObject go in refneticableObjList) {
			go.GetComponent<Rigidbody> ().velocity = (direction * refneticsSpeed);
		}
	}

	void OnTriggerStay(Collider col) 
	{
		//print(col.gameObject.name+" is staying");
		if (!refneticableObjList.Contains (col.gameObject))
			refneticableObjList.Add (col.gameObject);
	}

	void OnTriggerExit(Collider col) 
	{
		//print(col.gameObject.name+" exits");
		if (refneticableObjList.Contains (col.gameObject))
			refneticableObjList.Remove (col.gameObject);
	}

}
