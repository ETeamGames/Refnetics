using UnityEngine;
using System.Collections;

public class PutPathManager : MonoBehaviour {
    public GameObject[] objects;
    private GameObject ob;
    private Vector3 rot = new Vector3(0, 0, 0);
    public string PathName = "Path1";

    // Use this for initialization
    void Start () {
        int n = 1;
        ob = new GameObject();
        foreach (GameObject go in objects)
        {

            iTween.PutOnPath(go, iTweenPath.GetPath(PathName), 1f / objects.Length * n);
            iTween.PutOnPath(ob, iTweenPath.GetPath(PathName), 1f / objects.Length * n - 0.0001f);
            go.transform.LookAt(ob.transform);
            go.transform.Rotate(rot);
            n++;
        }
    }
	
	// Update is called once per frame
	void Update () {
    }
}
