using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[System.Serializable]
public class PUTPATHINFO
{
    public GameObject obj;
    public float position;
}

public class PutPathManager : MonoBehaviour
{
    public List<PUTPATHINFO> objects;
    private GameObject ob;
    private Vector3 rot = new Vector3(0, 0, 0);
    public string PathName = "Path1";

    // Use this for initialization
    void Start()
    {
        int n = 1;
        ob = new GameObject();
        foreach (PUTPATHINFO go in objects)
        {

            iTween.PutOnPath(go.obj, iTweenPath.GetPath(PathName), Mathf.Clamp(go.position, 0, 1));
            iTween.PutOnPath(ob, iTweenPath.GetPath(PathName), Mathf.Clamp(go.position - 0.0001f, 0, 1f));
            go.obj.transform.LookAt(ob.transform);
            go.obj.transform.Rotate(rot);
            n++;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}