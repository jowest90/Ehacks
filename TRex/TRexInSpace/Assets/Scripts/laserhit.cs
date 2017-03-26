using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserhit : MonoBehaviour {
    public float weapondamage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            enemyhealth hurt = other.gameObject.GetComponent<enemyhealth>();
            hurt.addamage(weapondamage);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemyhealth hurt = other.gameObject.GetComponent<enemyhealth>();
            hurt.addamage(weapondamage);
        }
    }
}
