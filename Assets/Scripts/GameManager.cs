using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public bool gameOver;

	void Awake() { 
		if (instance == null)
		{
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		gameOver = false;

        
	}
	
	// Update is called once per frame
	void Update () {

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        
    }

	public void StartGame() {
		UiManager.instance.GameStart();
		ScoreManager.instance.startScore();
		GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
	}

	public void GameOver() {
		UiManager.instance.GameOver();
		ScoreManager.instance.stopScore();
		gameOver = true;
	}
}
