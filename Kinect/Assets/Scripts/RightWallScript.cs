using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallScript : MonoBehaviour {

	private float speed = 6f; 
	void Update () {   
		float offset = Time.time * speed;       
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-offset, 0); 
	}
}
