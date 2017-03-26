using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour {
    public float speed = 2.0f;
    public int curhealth;
    public float projectileSpeed;
    public GameObject projectile;
    public float volume;
    public float firingRate = .2f;
    public Vector3 jump;
    public float jumpForce = 2f;
    public bool isGrounded;
    public bool jumpagain = true;
    AudioSource clickAudio;
    public int left = 0, right = 1;
    AudioClip jumpaudio;
    public AudioClip clip; // for jump
    public GameObject targetplayer; // player

	// Use this for initialization
	void Start () {
        clickAudio = GetComponent<AudioSource>();
        jump = new Vector3(0, 1f, 0);
        isGrounded = true;
    }




    // Update is called once per frame
    void Update()
    {

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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Rigidbody2D rigbody = GetComponent<Rigidbody2D>();
            //rigbody.GetComponent<AudioClip>.audio("PlayerJump.wav");
            //AudioSource.PlayClipAtPoint(clip, Vector3.zero, 1f);
            rigbody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            
            
          //  StartCoroutine(JumpRefreshTime()); // needed for a delay in jumping again
        }

        isGrounded = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Shredder") {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator JumpRefreshTime()
    {
        //    jumpagain = true;
        //    yield return new WaitForSeconds(2.0f);
        //    jumpagain = false;
        //    isGrounded = true;
        Rigidbody2D rigbody = GetComponent<Rigidbody2D>();
        //rigbody.velocity = Vector2.zero;
        //float timer = 0;
        //float jumpTime = 0;
        //Vector2 jumpVector = 0;

        //while (jumpButtonPressed && timer < jumpTime)
        //{
        //Calculate how far through the jump we are as a percentage
        //apply the full jump force on the first frame, then apply less force
        //each consecutive frame

        //float proportionCompleted = timer / jumpTime;
        //Vector2 thisFrame = Vector2.Lerp(jumpVector, Vector2.zero, proportionCompleted);
        //rigbody.AddForce(thisFrame);
        //timer += Time.deltaTime;
        yield return null;
        //}

        isGrounded = true;
    }

    //void OnCollisionEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    Destroy(collision.gameObject);
    //}

}
