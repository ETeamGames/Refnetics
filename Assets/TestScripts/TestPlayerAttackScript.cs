using UnityEngine;
using System.Collections;

public class TestPlayerAttackScript : MonoBehaviour {
    public Camera camera;
    public float bulletSpeed;
    public GameObject bullet;
    public float rayLimit;
    public TestPlayerController tpc;
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
    //PC用
    private void pcClickProc()
    {
        if (!Input.GetMouseButtonDown(0))
            return;
        //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLimit))
        {
            attack(hit.collider.gameObject);
        }
        else
        {
            attack(ray.direction);
        }
    }
    //スマホ用
    private void phoneClickProc()
    {
        if (Input.touchCount == 0)
            return;
        //メインカメラ上のマウスカーソルのある位置からRayを飛ばす
        Ray ray = camera.ScreenPointToRay(Input.GetTouch(1).position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            attack(hit.collider.gameObject);
        }
        else
        {
            attack(ray.direction);
        }
    }
    private void attack(GameObject hitObject)
    {
        Debug.Log("Attack " + hitObject.gameObject.name);
        GameObject b = (GameObject)Instantiate(bullet);
        b.transform.position = camera.transform.position;
        b.GetComponent<Rigidbody>().velocity = (hitObject.transform.position - camera.transform.position).normalized * (bulletSpeed + tpc.Speed);
    }
    private void attack(Vector3 direction)
    {
        GameObject b = (GameObject)Instantiate(bullet, camera.transform.position, bullet.transform.rotation);
        b.GetComponent<Rigidbody>().velocity = direction * (bulletSpeed + tpc.Speed);
    }
}
