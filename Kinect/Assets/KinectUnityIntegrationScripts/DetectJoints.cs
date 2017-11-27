using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class DetectJoints : MonoBehaviour {

	//Launching kinect and integrating with unity.

    public GameObject BodySrcManager;
    public JointType TrackedJoint;
    private BodySourceManager bodyManager;
    private Body[] bodies;
    private int multiplier = 10;
	private float wallCollision = 5.2f;
	private float roadCollision = -2.85f;
	private float jump = -1.5f;
	private bool jumping = false;
	private Animator anim;
	private GameManager gameManager;


	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		anim = GameObject.Find("Robot Kyle").GetComponent<Animator> ();
        if (BodySrcManager == null)
        { 
            Debug.Log("Assign GameObject with Body Source Manager");
        }
        else
        {
            bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = 0;
        if (bodyManager == null)
        {
			Debug.Log ("1");
            return;
        }
        bodies = bodyManager.GetData();
        if (bodies == null)
        {
			Debug.Log ("2");
            return;
        }
        foreach(var body in bodies)
        {
            if (body == null)
            {
				Debug.Log ("3");
                continue;
            }
			if (body.IsTracked) {
				if(gameManager.IsGameEnded==false){
					Time.timeScale = 1;
				}

				var pos = body.Joints [TrackedJoint].Position;
				gameObject.transform.position = new Vector3 (multiplier * pos.X, multiplier * pos.Y, -4f);

				if (transform.position.x > wallCollision) {
					transform.position = new Vector3 (wallCollision, transform.position.y, transform.position.z);

				} else if (transform.position.x < -wallCollision) {

					transform.position = new Vector3 (-wallCollision, transform.position.y, transform.position.z);
				}
				if (transform.position.y < roadCollision) {
					transform.position = new Vector3 (transform.position.x, roadCollision, transform.position.z);

				}
				if (transform.position.y >=	 jump) {
					anim.SetBool ("Jumping", true);
				} else {
					anim.SetBool("Jumping", false);
				}
			}
        }
	}
}
