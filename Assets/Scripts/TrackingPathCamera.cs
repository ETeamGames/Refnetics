using UnityEngine;
using System.Collections;

public class TrackingPathCamera : MonoBehaviour {
    public int time = 100;
    public string PathName = "Path1";
    public GameObject targetObj;

    void Start()
    {
        /*Hashtable param = new Hashtable();
        param.Add("time", time);
        param.Add("easeType", iTween.EaseType.easeInOutQuad);
        param.Add("onstarttarget", gameObject);
        param.Add("onstart", "startAction");
        param.Add("oncompletetarget", gameObject);
        param.Add("oncomplete", "compAction");
        param.Add("path", iTweenPath.GetPath(PathName));*/
        iTween.MoveTo(this.gameObject, iTween.Hash("time", time, "path", iTweenPath.GetPath(PathName), "oncomplete", "compAction", "oncompletetarget", gameObject, "onstart", "startAction", "onstarttarget", gameObject, "onupdate", "updateAction", "onupdatetarget", gameObject));
    }


    void Update()
    {
        if(targetObj != null)
            this.gameObject.transform.LookAt(targetObj.transform);
    }
}
