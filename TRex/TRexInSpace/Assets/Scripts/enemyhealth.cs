using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour {
    public float enemymaxhealth = 2;
     float currenthealth ;
	// Use this for initialization
	void Start () {
        currenthealth = enemymaxhealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addamage(float damage) {
        currenthealth -= damage;
        if(currenthealth <= 0)
        {
            makedead();
        }
    }

    void makedead()
    {
        Destroy(gameObject);
    }
}
