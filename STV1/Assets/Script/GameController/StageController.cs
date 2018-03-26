using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour 
{
	public int StageNumber;
	public GameObject Block;
	public GameObject BlackHole;
	float m_fScreenX;
	float m_fScreenY;
	float m_fBlackHoleRadius;
	int m_nBlockCountX;
	int m_nBlockCountY;
	float m_fBlockSizeX;
	float m_fBlokcSizeY;

	// Use this for initialization
	void Start () 
	{
		SetValue setValue = GameObject.Find("SetValue").GetComponent<SetValue>();
		m_fScreenX = setValue.globalScreen.ScreenX;
		m_fScreenY = setValue.globalScreen.ScreenY; 
		m_nBlockCountX = setValue.globalScreen.BlockCountX;
		m_nBlockCountY = setValue.globalScreen.BlockCountY;
		m_fBlockSizeX = setValue.globalScreen.BlockSizeX;
		m_fBlokcSizeY = setValue.globalScreen.BlockSizeY;
		m_fBlackHoleRadius = setValue.globalScreen.BlackHoleRadius;

		startStage( StageNumber);
	}
	
	public void startStage( int nStage)
	{
		makeAllBlock( nStage);
		resetBlackHole();
	}

	public void nextStage()
	{
		StageNumber++;
		resetBlackHole();
		makeAllBlock(StageNumber);
	}

	void makeAllBlock( int nBlockMax)
	{
		//블럭 생성
		//Debug.Log( "Random:" + (-m_nBlockCountY/2) + "," +  ((m_nBlockCountY/2) -1));
		for( int nBlock = 0; nBlock < nBlockMax; nBlock++)
		{
			int nPosX = Random.Range( -m_nBlockCountX/2, m_nBlockCountX/2);
			int nPosY = Random.Range( (-m_nBlockCountY/2) +1, (m_nBlockCountY/2)+1);
			//Debug.Log( nPosX + "," + nPosY);
			Vector2 vPos = new Vector2( nPosX * m_fBlockSizeX, nPosY * m_fBlokcSizeY);
			Instantiate( Block, vPos, Quaternion.identity);
		}
	}

	void resetBlackHole()
	{
			float fPosX = Random.Range( (-m_fScreenX/2.0f) + m_fBlackHoleRadius, (m_fScreenX/2.0f) - m_fBlackHoleRadius);
			float fPosY = Random.Range( (-m_fScreenY/2.0f) + m_fBlackHoleRadius, (m_fScreenY/2.0f) - m_fBlackHoleRadius);
			//Debug.Log( fPosX + "," + fPosY);
			BlackHole.transform.Translate( fPosX, fPosY, 0.0f);
	}
}
