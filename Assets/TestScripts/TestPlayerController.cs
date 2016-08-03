using UnityEngine;
using System.Collections;

public class TestPlayerController : MonoBehaviour {
    [SerializeField]
    private float speed;
    public float Speed
    {
        set
        {
            speed = value;
            changeSpeed(speed,0);
        }
        get
        {
            return speed;
        }
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void stop()
    {
        for(int n = 0;n < transform.childCount; n++)
        {
            transform.GetChild(n).GetComponent<TestCubeScript>().stop();
        }
    }
    public void start()
    {
        for (int n = 0; n < transform.childCount; n++)
        {
            transform.GetChild(n).GetComponent<TestCubeScript>().start();
        }
    }
    public void changeSpeed(float speed,float effectTime)
    {
        for (int n = 0; n < transform.childCount; n++)
        {
            transform.GetChild(n).GetComponent<TestCubeScript>().speedChange(speed,effectTime);
        }
    }
}
