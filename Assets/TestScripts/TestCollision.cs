using UnityEngine;
using System.Collections;

public class TestCollision : MonoBehaviour {
    public bool speedChange;
    public float speed;
    public float speedChangeTime;
    public bool stop;
   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (speedChange)
        {
            col.gameObject.transform.parent.GetComponent<TestPlayerController>().changeSpeed(speed,speedChangeTime);
        }
        if (stop)
        {
            col.gameObject.transform.parent.GetComponent<TestPlayerController>().stop();
        }
    }
}
