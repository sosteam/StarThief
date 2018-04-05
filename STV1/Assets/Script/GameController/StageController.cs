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
	GameObject Enemy02;
	GameObject Star;
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

	// 밸런스 관련
	int m_nBlockCount;
	int m_nEnemy01Count;
	int m_nEnemy02Count;
	
	// Use this for initialization
	void Start () 
	{
		ValueController valueController = GameObject.Find("ValueObject").GetComponent<ValueController>();
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
		if( playerController == null) Debug.Log("PlayerController is Null");
		Enemy01 = (GameObject)Resources.Load("Enemy01");
		Enemy02 = (GameObject)Resources.Load("Enemy02");
		Star = (GameObject)Resources.Load("Star");
		m_fScreenX = valueController.globalScreen.ScreenX;
		m_fScreenY = valueController.globalScreen.ScreenY; 
		m_fScreenHalfX = m_fScreenX / 2.0f;
		m_fScreenHalfY = m_fScreenY / 2.0f;
		m_nBlockCountX = valueController.globalScreen.BlockCountX;
		m_nBlockCountY = valueController.globalScreen.BlockCountY;
		m_fBlockSizeX = valueController.globalScreen.BlockSizeX;
		m_fBlokcSizeY = valueController.globalScreen.BlockSizeY;
		m_fBlackHoleRadius = valueController.globalScreen.BlackHoleRadius;

		StarReady();
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
		setBalance();
		BlackHoleReady();
		makeAllBlock();
		EnemyReady();
	}

	public void StageAction()
	{
		setRunning( true);

		playerController.movePlayer();

		//playerController.actionShooter();

		//EnemyAction();
	}

	void makeAllBlock()
	{
		//블럭 생성
		//Debug.Log( "Random:" + (-m_nBlockCountY/2) + "," +  ((m_nBlockCountY/2) -1));
		for( int nBlock = 0; nBlock < m_nBlockCount; nBlock++)
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

	void EnemyReady()
	{
		//Enemy01
		for( int nCount = 0; nCount < m_nEnemy01Count; nCount++)	//Ememy 갯수
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

		//Enemy02
		for( int nCount = 0; nCount < m_nEnemy02Count; nCount++)	//Ememy 갯수
		{
			float xPos = 0.0f, yPos = 0.0f;
			int nEdge = Random.Range(1, 5); // Top, Bottom, Left, Right 선정

			// Top에 생성. Top의 X축 선상. 최상단 Y값보다 1 낮은 곳에 있다.
			if( nEdge == 1)
			{
				xPos = Random.Range( -m_fScreenHalfX +1.0f, m_fScreenHalfX - 1.0f);
				yPos = m_fScreenY/2 -1.0f;
			}
			// Bottom에 생성. Bottom의 X축 선상. 최하단 보다 1 높은 곳에 있다.
			if( nEdge == 2)
			{
				xPos = Random.Range( -m_fScreenHalfX +1.0f, m_fScreenHalfX - 1.0f);
				yPos = -m_fScreenY/2 +1.0f;
			}
			// Left에 생성. Left의 Y축 선상.  최왼쪽 보다 1 오른쪽에 있다.
			if( nEdge == 3)
			{
				xPos = -m_fScreenX/2 +1.0f;
				yPos = Random.Range( -m_fScreenHalfY +1.0f, m_fScreenHalfY - 1.0f);
			}
			// Right에 생성. Rigt의 Y축 선상. 최 오른쪽 보다 1 왼쪽에 있다.
			if( nEdge == 4)
			{
				xPos = m_fScreenX/2 -1.0f;
				yPos = Random.Range( -m_fScreenHalfY +1.0f, m_fScreenHalfY - 1.0f);
			}

			GameObject farStar = getFarStar( xPos, yPos);
			if( farStar != null)
			{
				Vector2 vEnemy02 = new Vector2( xPos, yPos);  //출발위치
				//가장 멀리있는 Star를 향해서 방향을 잡는다.
				Vector2 vDirection = (new Vector2( farStar.transform.position.x, farStar.transform.position.y)) - ( new Vector2( xPos, yPos)); 
				//Debug.Log( "Enemy02 :" + vEnemy02);
				//Debug.Log( "farStar:" + farStar.transform.position);
				//Debug.Log( "Enemy02 vDirection:" + vDirection);
				//360 각도로 변경
				float fAngle = Mathf.Atan2(vDirection.y, vDirection.x) * Mathf.Rad2Deg;
				fAngle -= 90.0f;  //90도를 왜 빼 줘야 하는지 모르겠지만 더해 줘야 방향이 맞다.
				//Debug.Log( "fAngle:" + fAngle);
				//회전 설정
				Quaternion rotation = Quaternion.identity;
				rotation = Quaternion.AngleAxis(fAngle, Vector3.forward);
				Instantiate( Enemy02, vEnemy02, rotation);
			}
		}
	}

	GameObject getFarStar( float xPos, float yPos)
	{
		GameObject[] arrStar;
		float fLongest = 0;
		int nSelectedStar = 0;
  
        arrStar = GameObject.FindGameObjectsWithTag ("Star");
        int nCount = arrStar.Length;
		if( nCount == 0) return null;

		for( int i=0; i < nCount; i++)
		{
			Vector2 vEnemy02Pos =  new Vector2( xPos, yPos);
			Vector2 vStarPos = new Vector2( arrStar[i].transform.position.x, arrStar[i].transform.position.y);
			float fDistance = Vector2.Distance(vEnemy02Pos, vStarPos);

			if( fDistance > fLongest)  //가장 긴걸 교체
			{
				fLongest = fDistance;
				nSelectedStar = i;
			} 
		}

		//Debug.Log( arrStar[nSelectedStar].transform.position.x + "," + arrStar[nSelectedStar].transform.position.y);
		return arrStar[nSelectedStar];
	}

	void EnemyAction()
	{
		EnemyController enemyController = Enemy01.GetComponent<EnemyController>();
		enemyController.Move();
	}

	void StarReady()
	{
		Instantiate(Star, new Vector2( -2, -2), Quaternion.identity);
		Instantiate(Star, new Vector2( -2, 0), Quaternion.identity);
		Instantiate(Star, new Vector2( -2, 2), Quaternion.identity);
		Instantiate(Star, new Vector2( 0, -2), Quaternion.identity);
		Instantiate(Star, new Vector2( 0, 0), Quaternion.identity);
		Instantiate(Star, new Vector2( 0, 2), Quaternion.identity);
		Instantiate(Star, new Vector2( 2, -2), Quaternion.identity);
		Instantiate(Star, new Vector2( 2, 0), Quaternion.identity);
		Instantiate(Star, new Vector2( 2, 2), Quaternion.identity);
	}

	void setBalance()
	{
		//블럭은 1~10개가 반복된다.
		m_nBlockCount = StageNumber % 10;

		//difficalty 는 nStage /3 으로 1씩 증가
		int nDifficulty = StageNumber / 3;

		//Enemy02 은 diffilcuty / 3
		m_nEnemy02Count = nDifficulty / 10;

		//Enemy01은 difficulty % 10;
		m_nEnemy01Count = nDifficulty % 10;

		//Debug.Log( "BlockCount:" + m_nBlockCount);
		//Debug.Log( "Enemy01:" + m_nEnemy01Count);
		//Debug.Log( "Enemy02:" + m_nEnemy02Count);
	}
}