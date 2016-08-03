using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    private float startTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void pauseAnim()
    {
        iTween.Pause();
        Debug.Log("itween path pause");
    }
    public void resumeAnim()
    {
        iTween.Resume();

        //tc.resume(Time.time);
    }
    public void compAction()
    {
        Debug.Log("itween path complete");
        Debug.Log("time is " +  (Time.time - startTime).ToString());
    }
    public void startAction()
    {
        Debug.Log("itween path start");
        startTime = Time.time;
    }
    public void updateAction()
    {
        //Debug.Log("itween path update");
    }
}
