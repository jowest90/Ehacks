using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour {
  public float speed = 1.0f;
  public GameObject projectile;
  public float projectileSpeed;


	// Use this for initialization
	void Start () {

  }

	// Update is called once per frame
	void Update () {
    if(Input.GetKeyDown(KeyCode.Mouse0)){
      GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
      beam.Rigidbody2D.velocity = new Vector3(0,projectileSpeed,0);
    }

    if(Input.GetKey(KeyCode.LeftArrow)){
      transform.position += new Vector3(-speed * Time.deltaTime,0,0);
    }
     else if (Input.GetKey(KeyCode.RightArrow)){
      transform.position += new Vector3(speed* Time.deltaTime,0,0);
    }
  }


}
