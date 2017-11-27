using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	//Main functions - backend of game

    private GameObject heart1;
    private GameObject heart2;
    private GameObject heart3;
    private Text scoreText;
    private GameObject panel;

    private int life = 3;
    private int score = 0;
	private bool canBeHit = true;
	private bool isGameEnded = false;

	public bool IsGameEnded {
		get {
			return isGameEnded;
		}
	}

    // Use this for initialization
    void Start() {
        panel = GameObject.Find("Panel");
        panel.SetActive(false);
        heart1 = GameObject.Find("HeartImage 1");
        heart2 = GameObject.Find("HeartImage 2");
        heart3 = GameObject.Find("HeartImage 3");
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "Score: 0";

        StartCoroutine(StartScoreFunction());
    }

    // Update is called once per frame
    void Update() {

    }
	public void CheckCollider(Collider col)
    {
		if (canBeHit==true) {
			Debug.Log ("check");
			if (col.gameObject.name == "Horizontal Block(Clone)" || col.gameObject.name == "Vertical Block(Clone)") {
				life--;
				Debug.Log (life);
				Destroy (col.gameObject);
			}

			switch (life) {
			case 2:
				Destroy (heart1);
				break;
			case 1:
				Destroy (heart2);
				break;
			case 0:
				Destroy (heart3);
				EndGame ();
				break;
			}



			StartCoroutine(ExecuteAfterTime());
		}
        
    }


	IEnumerator ExecuteAfterTime()
	{
			canBeHit = false;
			yield return new WaitForSeconds(0.2f);
			canBeHit = true;

	}

	public void DestroyEnemyOnEnd(Collider col)
    {
        Debug.Log("2");
        Destroy(col.gameObject);
    }

    IEnumerator StartScoreFunction()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
			IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: "+score.ToString();
    }

    private void EndGame()
    {
        panel.SetActive(true);
		scoreText.text = "";
        Text finishScore = GameObject.Find("ScoreTextFinish").GetComponent<Text>();
        finishScore.text = "You scored\n" + this.score+ "\npoints !!!";
		isGameEnded = true;
        Time.timeScale = 0;

    }

    public void PlayAgain()
    {
        Application.LoadLevel("Game");
        Time.timeScale = 1;
    }
}
