using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour {
    public float speed = 2.0f;
    public float projectileSpeed;
    public GameObject projectile;
    public float firingRate = .2f;
	// Use this for initialization
	void Start () {
		
	}

   
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           // InvokeRepeating("FireProjectile", .000001f, firingRate);
            GameObject lazerbeam = Instantiate(projectile, transform.position, Quaternion.AngleAxis(90, Vector3.forward)) as GameObject;
            Rigidbody2D rigid = lazerbeam.GetComponent<Rigidbody2D>();
            rigid.AddForce(transform.forward * speed);
            lazerbeam.GetComponent<Rigidbody2D>().position = new Vector3(transform.position.x + 1, transform.position.y - .15f);
            lazerbeam.GetComponent<Rigidbody2D>().velocity = new Vector3(5, projectileSpeed);
           
            //transform.translate(Vector3.forward Time.deltaTime speed);
            // transform.Rotate(0, 0, lazerbeam.position.z);
             
            // Physics.IgnoreCollision(rigid.GetComponent<Collider2D>, playercontroller.GetComponent);
        }

        if (Input.GetKey(KeyCode.E))
        {
          //  gameObject.GetComponent<AudioSource>().Play();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
