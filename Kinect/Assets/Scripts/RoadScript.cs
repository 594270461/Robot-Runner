using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour {

	private float speed = 2f; 
	void Update () {   
		float offset = Time.time * speed;    
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset); 
	}
		
}
