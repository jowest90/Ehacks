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
    public float jumpForce = 2f;
    public bool isGrounded;
    public bool jumpagain = false;
    public AudioSource clickAudio;
    public int left = 0, right = 1;

	// Use this for initialization
	void Start () {
        jump = new Vector3(0, 1f, 0);
        isGrounded = true;
    }

    private IEnumerator JumpRefreshTime()
    {
        jumpagain = true;
        yield return new WaitForSeconds(2.0f);
        jumpagain = false;
        isGrounded = true;
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // InvokeRepeating("FireProjectile", .000001f, firingRate);
            if (right == 1)
            {
                GameObject lazerbeam = Instantiate(projectile, transform.position, Quaternion.AngleAxis(90, Vector3.forward)) as GameObject;
                Rigidbody2D rigid = lazerbeam.GetComponent<Rigidbody2D>();
                rigid.AddForce(transform.forward * speed);
                lazerbeam.GetComponent<Rigidbody2D>().position = new Vector3(transform.position.x + 1, transform.position.y - .15f);
                lazerbeam.GetComponent<Rigidbody2D>().velocity = new Vector3(5, projectileSpeed);

                //transform.translate(Vector3.forward Time.deltaTime speed);
                // transform.Rotate(0, 0, lazerbeam.position.z);

                Destroy(lazerbeam, 2.0f); // remove lazers after 2 secs
            } // if going right

            if (left == 1)
            {
                GameObject lazerbeam = Instantiate(projectile, transform.position, Quaternion.AngleAxis(90, Vector3.back)) as GameObject;
                Rigidbody2D rigid = lazerbeam.GetComponent<Rigidbody2D>();
                rigid.AddForce(-transform.forward * speed);
                lazerbeam.GetComponent<Rigidbody2D>().position = new Vector3(transform.position.x - 1, transform.position.y - .15f);
                lazerbeam.GetComponent<Rigidbody2D>().velocity = new Vector3(-5, projectileSpeed);

                //transform.translate(Vector3.forward Time.deltaTime speed);
                // transform.Rotate(0, 0, lazerbeam.position.z);

                Destroy(lazerbeam, 2.0f); // remove lazers after 2 secs
            } // if going left
        }

        if (Input.GetKey(KeyCode.E))
        {
          //  gameObject.GetComponent<AudioSource>().Play();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(-2f, 2f, 2f);
            left = 1; // now go left
            right = 0; // no more right

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(2f, 2f, 2f);
            right = 1; // now go right
            left = 0; // no more left
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            Rigidbody2D rigbody = GetComponent<Rigidbody2D>();
            //rigbody.GetComponent<AudioClip>.audio("PlayerJump.wav");
            rigbody.AddForce(jump*jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
//<<<<<<< HEAD
            isGrounded = true;
//=======
            clickAudio.Play(); // play jump sound
            StartCoroutine(JumpRefreshTime()); // needed for a delay in jumping again
//>>>>>>> refs/remotes/origin/master
        }

    }
}
