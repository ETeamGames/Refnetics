using UnityEngine;
using System.Collections;

public class TestEnemyGroupScriot : MonoBehaviour {
    public TestEnemyScript[] enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void collider(Collider col)
    {
        Debug.Log("Collision EnemyGroup tag:"+col.gameObject.tag);
        if (col.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Collision EnemyGroup - Player");
            foreach (TestEnemyScript t in enemy)
            {
                t.attack(col.gameObject);
            }
        }
    }

}
