using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	public static UiManager instance;

	public GameObject zigzagPanel;
	public GameObject gameoverPanel;
	public GameObject tapText;
	public Text score;
	public Text highScore1;
	public Text highScore2;
	// Use this for initialization

	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}

	void Start () {
		highScore1.text = "High Score : " + PlayerPrefs.GetInt("highScore");
	}

	public void GameStart() {
		
		tapText.SetActive(false);
		zigzagPanel.GetComponent<Animator>().Play("panelUp");
	}

	public void GameOver() {
		score.text = PlayerPrefs.GetInt("score").ToString();
		highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
		gameoverPanel.SetActive(true);
	}

	public void playAgain() {
		SceneManager.LoadScene(0);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
