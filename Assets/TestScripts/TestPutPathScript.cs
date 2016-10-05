using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[System.Serializable]
public class PUTPATHINFO
{
    public GameObject obj;
    public GameObject collider;
    [Range(0,1)]
    public float position;
    [Range(0,1)]
    public float colPosition;
}

[ExecuteInEditMode]
public class TestPutPathScript : MonoBehaviour
{
    public bool inspectorEdit = true;
    public List<PUTPATHINFO> objects;
    public GameObject lookObject;
    private Vector3 rot = new Vector3(0, 0, 0);
    public string PathName = "Path1";

    // Use this for initialization
    void Start()
    {
        foreach (PUTPATHINFO go in objects)
        {
            iTween.PutOnPath(go.obj, iTweenPath.GetPath(PathName), Mathf.Clamp(go.position, 0, 1));
            iTween.PutOnPath(lookObject, iTweenPath.GetPath(PathName), Mathf.Clamp(go.position - 0.0001f, 0, 1f));
            if(go.collider != null)
                iTween.PutOnPath(go.collider, iTweenPath.GetPath(PathName), Mathf.Clamp(go.colPosition, 0, 1));
            go.obj.transform.LookAt(lookObject.transform);
            go.obj.transform.Rotate(rot);
        }
    }

    void put()
    {
        foreach (PUTPATHINFO go in objects)
        {
            iTween.PutOnPath(go.obj, iTweenPath.GetPath(PathName), Mathf.Clamp(go.position, 0, 1));
            iTween.PutOnPath(lookObject, iTweenPath.GetPath(PathName), Mathf.Clamp(go.position - 0.0001f, 0, 1f));
            if (go.collider != null)
                iTween.PutOnPath(go.collider, iTweenPath.GetPath(PathName), Mathf.Clamp(go.colPosition, 0, 1));
            go.obj.transform.LookAt(lookObject.transform);
            go.obj.transform.Rotate(rot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (PUTPATHINFO go in objects)
        {
            iTween.PutOnPath(go.obj, iTweenPath.GetPath(PathName), Mathf.Clamp(go.position, 0, 1));
            iTween.PutOnPath(ob, iTweenPath.GetPath(PathName), Mathf.Clamp(go.position - 0.0001f, 0, 1f));
            if (go.collider != null)
                iTween.PutOnPath(go.collider, iTweenPath.GetPath(PathName), Mathf.Clamp(go.colPosition, 0, 1));
            go.obj.transform.LookAt(ob.transform);
            go.obj.transform.Rotate(rot);
        }*/
    }

    void OnValidate()
    {
        if(inspectorEdit)
            put();
    }
}