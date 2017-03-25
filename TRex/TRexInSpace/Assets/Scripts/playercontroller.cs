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

    //void FireProjectile()
    //{
    //   GameObject lazerbeam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
    //   lazerbeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
            
    //}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           // InvokeRepeating("FireProjectile", .000001f, firingRate);
            GameObject lazerbeam = Instantiate(projectile, transform.position, Quaternion.AngleAxis(90, Vector3.forward)) as GameObject;
            lazerbeam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            Rigidbody2D rigid = lazerbeam.GetComponent<Rigidbody2D>();
           // transform.Rotate(0, 0, lazerbeam.position.z);
           // rigid.AddForce(transform.forward * speed);
           // Physics.IgnoreCollision(rigid.GetComponent<Collider2D>, playercontroller.GetComponent);
        }

        //if (Input.GetKeyUp(KeyCode.Mouse1))
        //{
        //    CancelInvoke("FireProjectile");
        //}

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
