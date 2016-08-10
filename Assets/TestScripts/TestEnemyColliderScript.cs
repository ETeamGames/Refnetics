using UnityEngine;
using System.Collections;

public class TestEnemyColliderScript : MonoBehaviour {
    [SerializeField]
    private TestEnemyGroupScriot tegs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        tegs.collider(col);
    }
}
