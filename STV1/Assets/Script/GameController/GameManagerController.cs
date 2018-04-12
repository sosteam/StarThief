using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour 
{
	public static GameManagerController Instance;
	public int Score = 0;
	public int Coin = 0;
	Text textScoreCoin;

	void Awake() 
	{
		GameManagerController.Instance = this;	
	}

	// Use this for initialization
	void Start () 
	{
		textScoreCoin = GameObject.Find("ScoreCoin").GetComponent<UnityEngine.UI.Text>(); 
	}
	
	public void resetGame()
	{
		Score = 0;
		Coin = 0;
	}

	public void addScore( int nScore)
	{
		Score += nScore;
		drawText();
	}

    public void addCoin( int nCoin)
	{
		Coin += nCoin;
		drawText();
	}

	void drawText()
	{
		textScoreCoin.text = "Score " + Score + "Coin " + Coin;
	}

	public void OnClick3lineButton()
	{
		Debug.Log("Click 3LineButton");
	}

}
