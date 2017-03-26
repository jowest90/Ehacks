using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydamage : MonoBehaviour {
    public float damage;
    public float damageweight;
    public float pushbackforce;
    float nextDamage;

	// Use this for initialization
	void Start () {
        nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && nextDamage < Time.time)
        {
            playerhealth actualhealth = other.gameObject.GetComponent<playerhealth>();
            actualhealth.addamage(damage);
            nextDamage = Time.time + damageweight;
        }
        pushback(other.transform);
    }

    void pushback(Transform pushedObject)
    {
        Vector2 pushdirection = new Vector2(0, pushedObject.position.y - transform.position.y).normalized;
        pushdirection *= pushbackforce;
        Rigidbody2D rigid = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;
        rigid.AddForce(pushdirection, ForceMode2D.Impulse);
    }
}
