using UnityEngine;
using System.Collections;

public class TestTrackingPathCameraScript : MonoBehaviour
{
    public float time = 1f;
    public string PathName = "Path1";
    public GameObject targetObj;
    public bool target;
    private float timeBuffer;
    private float pauseTime;

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
        if (!target)
            iTween.MoveTo(this.gameObject, iTween.Hash("time", time, "path", iTweenPath.GetPath(PathName), "oncomplete", "compAction", "oncompletetarget", gameObject, "onstart", "startAction", "onstarttarget", gameObject, "onupdate", "updateAction", "onupdatetarget", gameObject));
    }


    void FixedUpdate()
    {
        if (target)
        {
            iTween.PutOnPath(this.gameObject, iTweenPath.GetPath(PathName), Mathf.Clamp((timeBuffer + time) / Time.time, 0, 1));
            return;
        }
        if (targetObj != null)
            this.gameObject.transform.LookAt(targetObj.transform);
    }

    void Update()
    {
    }

    public void start(float time)
    {
        timeBuffer = time;
    }

    public void pause(float time)
    {
        pauseTime = time;
    }

    public void resume(float time)
    {
        timeBuffer += time - pauseTime;
    }
}
