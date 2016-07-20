using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void pauseAnim()
    {
        iTween.Pause();
    }
    public void resumeAnim()
    {
        iTween.Resume();
    }
    public void compAction()
    {
        Debug.Log("itween path complete");
    }
    public void startAction()
    {
        Debug.Log("itween path start");
    }
    public void updateAction()
    {
        Debug.Log("itween path update");
    }
}
