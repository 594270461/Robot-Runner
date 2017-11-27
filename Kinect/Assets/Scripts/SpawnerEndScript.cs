using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEndScript : MonoBehaviour {

	//Script for destroying unused obstacles.

	private GameManager gameManager;
	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	void OnTriggerEnter(Collider col)
	{
		gameManager.DestroyEnemyOnEnd (col);
	}
}
