using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// RefneticsFieldに関連する処理を使うクラス
/// </summary>
public class PlayerRefneticsScript : MonoBehaviour {
	public Camera camera;
	/// <summary> 反射した際のスピード</summary>
	public float refneticsSpeed;
	public float rayLimit;

	public List<GameObject> refneticableObjList;
	[SerializeField] public GameObject targetCursor;

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
	/// Refnetics範囲内にある全オブジェクトをクリック方向に反射
	/// </summary>
	/// <param name = "direction"> クリック方向.</param>
	private void refnetics(Vector3 direction)
	{
		foreach (GameObject go in refneticableObjList) {
			go.GetComponent<Rigidbody> ().velocity = (direction * refneticsSpeed);
		}
	}

	/// <summary>
	/// RefneticsField内に対象が入った際の処理
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col)
	{
		//print(col.gameObject.name+" is entering");
		if (!refneticableObjList.Contains (col.gameObject)) {
			refneticableObjList.Add (col.gameObject);
			// target cursorを対象にアタッチ
			GameObject go = (GameObject)Instantiate(targetCursor, col.gameObject.transform.position, col.gameObject.transform.rotation);
			go.transform.SetParent (col.gameObject.transform, true);
		}
	}

	/*void OnTriggerStay(Collider col) 
	{
		//print(col.gameObject.name+" is staying");
		if (!refneticableObjList.Contains (col.gameObject))
			refneticableObjList.Add (col.gameObject);
	}*/

	/// <summary>
	/// RefneticsField内から対象が出た際の処理
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerExit(Collider col) 
	{
		//print(col.gameObject.name+" exits");
		if (refneticableObjList.Contains (col.gameObject)) {
			refneticableObjList.Remove (col.gameObject);
			Destroy(col.gameObject.transform.FindChild(ParamsEnum.TARGET_CURSOR_NAME).gameObject);
		}
	}

}
