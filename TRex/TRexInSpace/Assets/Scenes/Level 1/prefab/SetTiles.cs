using System.Collections;
using System.Collections.Generic;
using UnityEngine;

RequireComponent(typeof(MeshRenderer))] public class SetTiles : MonoBehaviour { public Vector2 tiling;

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer>().material.mainTextureScale = tiling;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
