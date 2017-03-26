using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	public float health = 150f;
	int waitingTime =2;
	 float timer;
	 public GameObject projectile;
	 //public GameObject enemyPrefab;
	 public float speed = 2.0f;
	 public float projectileSpeed;
	 public float firingRate = .2f;
	 public Vector3 jump;
	 public float jumpForce = 2f;
	 public bool isGrounded;
	 public bool jumpagain = false;
	 public AudioSource clickAudio;
	 public int left = 0, right = 1;
	// Use this for initialization
	void Start () {
		//Instantiate(enemyPrefab, new Vector3(-3,-3,0),Quaternion.identity);

	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
     if(timer > waitingTime){
			 GameObject lazerbeam = Instantiate(projectile, transform.position, Quaternion.AngleAxis(90, Vector3.back)) as GameObject;
			Rigidbody2D rigid = lazerbeam.GetComponent<Rigidbody2D>();
			rigid.AddForce(-transform.forward * speed);
			lazerbeam.GetComponent<Rigidbody2D>().position = new Vector3(transform.position.x - 1, transform.position.y - .15f);
			lazerbeam.GetComponent<Rigidbody2D>().velocity = new Vector3(-5, projectileSpeed);
			  Destroy(lazerbeam, 2.0f);
        timer = 0;
     }
	}

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -=missile.getDamage();
			if(health <=0){
				Destroy(gameObject);
			}
		}
	}

}
