using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour 
{
	public int StageNumber;
	PlayerController playerController;
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
		ValueController valueController = GameObject.Find("ValueObject").GetComponent<ValueController>();
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
		if( playerController == null) Debug.Log("PlayerController is Null");
		Enemy01 = (GameObject)Resources.Load("Enemy01");
		m_fScreenX = valueController.globalScreen.ScreenX;
		m_fScreenY = valueController.globalScreen.ScreenY; 
		m_fScreenHalfX = m_fScreenX / 2.0f;
		m_fScreenHalfY = m_fScreenY / 2.0f;
		m_nBlockCountX = valueController.globalScreen.BlockCountX;
		m_nBlockCountY = valueController.globalScreen.BlockCountY;
		m_fBlockSizeX = valueController.globalScreen.BlockSizeX;
		m_fBlokcSizeY = valueController.globalScreen.BlockSizeY;
		m_fBlackHoleRadius = valueController.globalScreen.BlackHoleRadius;

		StageReady();
	}
	
	public bool getRunning()
	{
		return m_isRunning;
	}

	public void setRunning( bool bRunning)
	{
		m_isRunning = bRunning;
	}

	public void StageReady()
	{
		setRunning( false);

		//Player멈춤
		playerController.stopPlayer();
		//Ready Next Stage 
		StageNumber++;
		BlackHoleReady();
		makeAllBlock(StageNumber);
		EnemyReady(StageNumber);
	}

	public void StageAction()
	{
		setRunning( true);

		playerController.movePlayer();

		//playerController.actionShooter();

		//EnemyAction();
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

	void BlackHoleReady()
	{
			float fPosX = Random.Range( -m_fScreenHalfX + m_fBlackHoleRadius, m_fScreenHalfX - m_fBlackHoleRadius);
			float fPosY = Random.Range( -m_fScreenHalfY + m_fBlackHoleRadius, m_fScreenHalfY - m_fBlackHoleRadius);
			//Debug.Log( fPosX + "," + fPosY);
			BlackHole.transform.Translate( fPosX, fPosY, 0.0f);
	}

	void EnemyReady(int nStage)
	{
		//위치 선정
		for( int nCount = 0; nCount < StageNumber; nCount++)
		{
			float xPos = 0.0f, yPos = 0.0f;
			int nEdge = Random.Range(1, 5); // Top, Bottom, Left, Right 선정
			int nStartRotation = 0;

			// Top에 생성. Top의 X축 선상. 최상단 Y값보다 1 낮은 곳에 있다.
			if( nEdge == 1)
			{
				xPos = Random.Range( -m_fScreenHalfX +1.0f, m_fScreenHalfX - 1.0f);
				yPos = m_fScreenY/2 -1.0f;
				nStartRotation = 180;
			}
			// Bottom에 생성. Bottom의 X축 선상. 최하단 보다 1 높은 곳에 있다.
			if( nEdge == 2)
			{
				xPos = Random.Range( -m_fScreenHalfX +1.0f, m_fScreenHalfX - 1.0f);
				yPos = -m_fScreenY/2 +1.0f;
				nStartRotation = 0;
			}
			// Left에 생성. Left의 Y축 선상.  최왼쪽 보다 1 오른쪽에 있다.
			if( nEdge == 3)
			{
				xPos = -m_fScreenX/2 +1.0f;
				yPos = Random.Range( -m_fScreenHalfY +1.0f, m_fScreenHalfY - 1.0f);
				nStartRotation = -90;
			}
			// Right에 생성. Rigt의 Y축 선상. 최 오른쪽 보다 1 왼쪽에 있다.
			if( nEdge == 4)
			{
				xPos = m_fScreenX/2 -1.0f;
				yPos = Random.Range( -m_fScreenHalfY +1.0f, m_fScreenHalfY - 1.0f);
				nStartRotation = 90;
			}

			//Debug.Log( nEdge + ", " + xPos + ", " + yPos);
			Vector2 vEnemy01 = new Vector2( xPos, yPos);
			Quaternion rotation = Quaternion.identity;
			rotation.eulerAngles = new Vector3(0, 0, nStartRotation); 
			Instantiate(Enemy01, vEnemy01, rotation);
		}
	}

	void EnemyAction()
	{
		EnemyController enemyController = Enemy01.GetComponent<EnemyController>();
		enemyController.Move();
	}
}