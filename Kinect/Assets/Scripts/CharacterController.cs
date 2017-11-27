using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
 {

	//Controller for character

	private GameManager gameManager;
	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

    private float speed = 5f;

	void OnTriggerEnter(Collider col)
    {
		gameManager.CheckCollider(col);
    }
    void Update()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += Vector3.down * speed * Time.deltaTime;
		}


	 
			
	}

}
