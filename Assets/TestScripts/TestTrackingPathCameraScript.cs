using UnityEngine;

public class TestTrackingPathCameraScript : MonoBehaviour
{
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
        //if (!target)
          //  iTween.MoveTo(this.gameObject, iTween.Hash("time", time, "path", iTweenPath.GetPath(PathName), "oncomplete", "compAction", "oncompletetarget", gameObject, "onstart", "startAction", "onstarttarget", gameObject, "onupdate", "updateAction", "onupdatetarget", gameObject));
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
