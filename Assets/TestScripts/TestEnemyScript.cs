using UnityEngine;
using System.Collections;

public class TestEnemyScript : MonoBehaviour {
    [SerializeField]
    public GameObject bullet;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void attack(GameObject target)
    {
        GameObject go = (GameObject)Instantiate(bullet, this.transform.position, this.transform.rotation);
        go.GetComponent<TestBulletScript>().Target = target;
    }
}
