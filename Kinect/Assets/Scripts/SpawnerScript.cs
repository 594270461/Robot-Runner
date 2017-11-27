using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

	//Spawning obstacles

    private GameObject horizontalBlock;    
	private GameObject verticalBlock;	// The enemy prefab to be spawned.
	private GameObject road;
	private GameObject road2;
	private GameObject leftWall;
	private GameObject leftWall2;
	private GameObject rightWall;
	private GameObject rightWall2;

    private float spawnTime = 2.5f;            // How long between each spawn.
    private float spawnRate = 0.1f;
	private float[] horizontalPlacementNumbers = new float[]{-1f, 5f};
	private float[] verticalPlacementNumbers = new float[]{-4f, 0f, 4f};
	private float speed;

	public float Speed {
		get {
			return speed;
		}
	}



    void Start()
    {
		speed = 20f;
		horizontalBlock = (GameObject)Resources.Load("Horizontal Block", typeof(GameObject));
		verticalBlock = (GameObject)Resources.Load("Vertical Block", typeof(GameObject));
		road = GameObject.Find("Road");
		road2 = GameObject.Find("Road (1)");
		leftWall = GameObject.Find("WallLeft");
		leftWall2 = GameObject.Find("WallLeft (1)");
		rightWall = GameObject.Find("WallRight");
		rightWall2 = GameObject.Find("WallRight (1)");

		StartCoroutine(SpawnFunction());
    }

	void Update(){

		TranslateStaticObjects(road);
		TranslateStaticObjects(road2);
		TranslateStaticObjects(leftWall);
		TranslateStaticObjects(leftWall2);
		TranslateStaticObjects(rightWall);
		TranslateStaticObjects(rightWall2);

	}

	void TranslateStaticObjects(GameObject gameObject){
		gameObject.transform.Translate(0f, 0f, -speed * Time.deltaTime); 
		if(gameObject.transform.position.z <= -510)    {    
			gameObject.transform.Translate(0f, 0f, 1960f);   
		}


	}


	IEnumerator SpawnFunction()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(2);
        }
    }

	//5f//-1f
    void Spawn()
    {
		
        Vector3 pos = transform.position;
		Instantiate(horizontalBlock, new Vector3(pos.x , pos.y+horizontalPlacementNumbers[Random.Range(0, horizontalPlacementNumbers.Length)],
			pos.z), Quaternion.Euler(0, 0, 90));
		Instantiate(verticalBlock, new Vector3(pos.x+verticalPlacementNumbers[Random.Range(0, verticalPlacementNumbers.Length)], pos.y+2f,
		    pos.z), Quaternion.identity);
		speed = speed + 3f;
//		Instantiate(horizontalBlock, new Vector3(pos.x, pos.y+horizontalPlacementNumbers[Random.Range(0, horizontalPlacementNumbers.Length)],
//        pos.z), Quaternion.identity);
//		Instantiate(verticalBlock, new Vector3(pos.x+verticalPlacementNumbers[Random.Range(0, verticalPlacementNumbers.Length)] , pos.y+2f,
//			pos.z), Quaternion.Euler(0, 0, 90));
//		Instantiate(enemy, new Vector3(pos.x, pos.y ,
//		        pos.z), Quaternion.identity);
//        if (spawnTime > spawnRate * 8)
//        {
//            spawnTime -= spawnRate;
//        }
//        Debug.Log("proper" + spawnTime);
    }
















    //   private float spawnThreshold = 100;
    //   private float spawnDecrement = 4;
    //   public GameObject enemy;
    //   void Start() { }
    //   void Update()
    //   {
    //if (Random.Range(0, spawnThreshold) <= 1)
    //       {
    //           Debug.Log("SpawnTreshold"+spawnThreshold);
    //           Vector3 pos = transform.position;
    //           Instantiate(enemy, new Vector3(pos.x +Random.Range(-10, 10), pos.y + Random.Range(-5.5f, 5.5f),
    //           pos.z), Quaternion.identity);
    //           spawnThreshold -= spawnDecrement;
    //           if (spawnThreshold < 4)
    //           {
    //               spawnThreshold = 4;
    //           }
    //       }
    //   }
}
