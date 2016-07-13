using UnityEngine;
using System.Collections;

public class TrackingPathCamera : MonoBehaviour {
    public int time = 100;
    public string PathName = "Path1";
    public GameObject targetObj;

    void Start()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath(PathName), "time", time));
    }


    void Update()
    {
        if(targetObj != null)
            this.gameObject.transform.LookAt(targetObj.transform);
    }
}
