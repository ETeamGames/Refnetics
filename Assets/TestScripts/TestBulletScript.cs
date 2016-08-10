using UnityEngine;
using System.Collections;

public class TestBulletScript : MonoBehaviour {
    [SerializeField]
    private float speed;
    private GameObject target;
    public GameObject Target
    {
        set
        {
            target = value;
            setVelocity();
        }
        get { return target; }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void setVelocity()
    {
        this.transform.LookAt(target.transform);
        GetComponent<Rigidbody>().velocity = this.transform.forward.normalized * speed;
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Bullet Collision " + col.tag);
        if (col.gameObject.tag.Equals("EnemyCollider"))
        {
            Destroy(gameObject);
        }
    }
}
