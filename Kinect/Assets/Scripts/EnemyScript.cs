using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	//Obstacle Script - movement


	private SpawnerScript spawnerScript;
    // Use this for initialization
	void Start(){
	
		spawnerScript = GameObject.Find("Spawner").GetComponent<SpawnerScript>();
	
	}
	void Update () {
		Vector3 actualPosition = transform.position;
		Vector3 movement = new Vector3(actualPosition.x, actualPosition.y, actualPosition.z - spawnerScript.Speed*Time.deltaTime);
		transform.position = movement;

	}

}
