using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour {
    public float speed = 2.0f;
    public float projectileSpeed;
    public GameObject projectile;
    public float firingRate = .2f;
    public Vector3 jump;
    public float jumpForce = 1f;
    public bool isGrounded;

	// Use this for initialization
	void Start () {
        jump = new Vector3(0, 1.2f, 0);
        isGrounded = true;
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

            Destroy(lazerbeam, 3.0f); // remove lazers
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

        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            Rigidbody2D rigbody = GetComponent<Rigidbody2D>();
            rigbody.AddForce(jump, ForceMode2D.Impulse);
            isGrounded = false;
            yield WaitForSeconds(3);
            isGrounded = true;
        }
        
    }
}
