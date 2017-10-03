using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static GameManager instance;

	[SerializeField] Text highScoreText;
	[SerializeField] Text scoreText;

	//Public keyword will be removed later
	public int highScore = 0;
	public float score = 0;
	bool playerAlive = false;

	void Awake()
	{
		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy (this.gameObject);
	}

	void Start()
	{
		GetSavedScore ();
	}

	void Update()
	{
		if(playerAlive)
			score += Time.deltaTime;

		//This functionality is added later
		if(scoreText != null)
			scoreText.text = "Score: " + (int)score;
	}

	void OnDisable()
	{
		SaveScore ();
	}

	void GetSavedScore()
	{
		highScore = PlayerPrefs.GetInt ("HighScore");
		//This functionality is added later
		if(highScoreText != null)
			highScoreText.text = "High Score: " + highScore;
	}

	void SaveScore()
	{
		if(score > highScore)
			PlayerPrefs.SetInt("HighScore", (int)score);
	}

	public void AddToScore(float amount)
	{
		if(playerAlive)
			score += amount;
	}

	public void StartScoring()
	{
		playerAlive = true;
	}

	public void StopScoring()
	{
		playerAlive = false;
	}
}
