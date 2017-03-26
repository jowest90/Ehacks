using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour {
    public float fullhealth;
    float currenthealth;
    public GameObject deathFX;
    playercontroller controlMovement;

	// Use this for initialization
	void Start () {
        currenthealth = fullhealth;
        controlMovement = GetComponent<playercontroller>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addamage(float damage)
    {
        
        if (damage <= 0)
        {
            return;
        }
        currenthealth -= damage;

        if (currenthealth <= 0)
            makedead();
    }

    void makedead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
