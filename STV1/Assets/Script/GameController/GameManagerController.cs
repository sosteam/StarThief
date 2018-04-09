using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour 
{
	public static GameManagerController Instance;
	public static int Score = 0;
	public static int Coin = 0;

	void Awake() 
	{
		GameManagerController.Instance = this;	
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	public void resetGame()
	{
		Score = 0;
		Coin = 0;
	}

	public void addScore( int nScore)
	{
		Score += nScore;
	}

    public void addCoin( int nCoin)
	{
		Coin += nCoin;
	}

}
