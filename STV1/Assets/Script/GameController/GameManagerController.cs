using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour 
{
	public static GameManagerController Instance;
	//GameObject objMainCanvas;
	GameObject objMenuPanel; // Assign in inspector
	CanvasGroup canvasGroupMenuPanel;

	public bool isPause = false;
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
		//objMainCanvas = GameObject.Find("MainCanvas");
		objMenuPanel = GameObject.Find("MenuPanel");
		
		canvasGroupMenuPanel = objMenuPanel.GetComponent<CanvasGroup>();
		canvasGroupMenuPanel.alpha = 0;
		canvasGroupMenuPanel.interactable = false;
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

	public bool getPause()
	{
		return isPause;
	}

	public void checkStarCount()
	{
		
	}

	public void OnClick3lineButton()
	{
        Time.timeScale = 0;  // 시간을 멈춤
        isPause = true;
		// Debug.Log( canvasGroupMenuPanel.interactable);
		canvasGroupMenuPanel.alpha = 1;
		canvasGroupMenuPanel.interactable = true;
		// Debug.Log( canvasGroupMenuPanel.interactable);
	}

	public void OnClickContinue()
	{
		canvasGroupMenuPanel.alpha = 0;
		canvasGroupMenuPanel.interactable = false;
		Time.timeScale = 1; // 시간을 재개
        isPause = false;
	}

	public void OnClickShop()
	{
		
	}

	public void OnClickSetting()
	{
		
	}

	public void OnClickExit()
	{
		
	}

	public void OnClickRestart()
	{
		
	}

}
