using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour 
{
	public int StageNumber;
	public GameObject Block;
	public GameObject BlackHole;
	GameObject Enemy01;
	float m_fScreenX;
	float m_fScreenY;
	float m_fScreenHalfX;
	float m_fScreenHalfY;
	float m_fBlackHoleRadius;
	int m_nBlockCountX;
	int m_nBlockCountY;
	float m_fBlockSizeX;
	float m_fBlokcSizeY;
	float m_fEnemy01Speed;
	bool m_isRunning = false;

	// Use this for initialization
	void Start () 
	{
		SetValue setValue = GameObject.Find("SetValue").GetComponent<SetValue>();
		Enemy01 = (GameObject)Resources.Load("Enemy01");
		m_fScreenX = setValue.globalScreen.ScreenX;
		m_fScreenY = setValue.globalScreen.ScreenY; 
		m_fScreenHalfX = m_fScreenX / 2.0f;
		m_fScreenHalfY = m_fScreenY / 2.0f;
		m_nBlockCountX = setValue.globalScreen.BlockCountX;
		m_nBlockCountY = setValue.globalScreen.BlockCountY;
		m_fBlockSizeX = setValue.globalScreen.BlockSizeX;
		m_fBlokcSizeY = setValue.globalScreen.BlockSizeY;
		m_fBlackHoleRadius = setValue.globalScreen.BlackHoleRadius;

		StageReady();
	}
	
	pubiic bool getRunning()
	{
		return m_isRunning;
	}

	public void setRunning( bool bRunning)
	{
		m_isRunning = bRunning;
	}

	public void StageReady()
	{
		StageNumber++;
		resetBlackHole();
		makeAllBlock(StageNumber);
		resetEnemy(StageNumber);
	}

	public void StageAction()
	{
		setRunning( true);
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
			float fPosX = Random.Range( -m_fScreenHalfX + m_fBlackHoleRadius, m_fScreenHalfX - m_fBlackHoleRadius);
			float fPosY = Random.Range( -m_fScreenHalfY + m_fBlackHoleRadius, m_fScreenHalfY - m_fBlackHoleRadius);
			//Debug.Log( fPosX + "," + fPosY);
			BlackHole.transform.Translate( fPosX, fPosY, 0.0f);
	}

	void resetEnemy(int nStage)
	{
		//위치 선정
		for( int nCount = 0; nCount < StageNumber; nCount++)
		{
			float xPos = 0.0f, yPos = 0.0f;
			int nEdge = Random.Range(1, 5); // Top, Bottom, Left, Right 선정
			Vector2 vDirection = new Vector2( 0, 0);

			// Top에 생성. Top의 X축 선상. 최상단 Y값보다 1 낮은 곳에 있다.
			if( nEdge == 1)
			{
				xPos = Random.Range( -m_fScreenHalfX +1.0f, m_fScreenHalfX - 1.0f);
				yPos = m_fScreenY/2 -1.0f;
				vDirection = new Vector2( 0, -1);
			}
			// Bottom에 생성. Bottom의 X축 선상. 최하단 보다 1 높은 곳에 있다.
			if( nEdge == 2)
			{
				xPos = Random.Range( -m_fScreenHalfX +1.0f, m_fScreenHalfX - 1.0f);
				yPos = -m_fScreenY/2 +1.0f;
				vDirection = new Vector2( 0, 1);
			}
			// Left에 생성. Left의 Y축 선상.  최왼쪽 보다 1 오른쪽에 있다.
			if( nEdge == 3)
			{
				xPos = -m_fScreenX/2 +1.0f;
				yPos = Random.Range( -m_fScreenHalfY +1.0f, m_fScreenHalfY - 1.0f);
				vDirection = new Vector2( 1, 0);
			}
			// Right에 생성. Rigt의 Y축 선상. 최 오른쪽 보다 1 왼쪽에 있다.
			if( nEdge == 4)
			{
				xPos = m_fScreenX/2 -1.0f;
				yPos = Random.Range( -m_fScreenHalfY +1.0f, m_fScreenHalfY - 1.0f);
				vDirection = new Vector2( -1, 0);
			}

			//Debug.Log( nEdge + ", " + xPos + ", " + yPos);
			//Enemy01 = (GameObject)Instantiate(Resources.Load("Enemy01"));
			Instantiate(Enemy01, new Vector2( xPos, yPos), Quaternion.identity);
			//Instantiate( Enemy01, new Vector2( xPos, yPos), Quaternion.identity);

		}
	}
}
