using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	float m_fPlayerMoveSpeed;
	float m_fPlayerRotateSpeed;
	StageController m_stageController;
	Rigidbody2D m_rb;
	Vector3 m_vMousePosition;
	Vector2 m_vDirection;
	LineRenderer m_lineRenderer;
	bool m_isPushPosition = false;
	float m_fShooter0Rate;
	float m_fShooter0Distance;
	float m_fBulletC0L01MoveSpeed;
	GameObject m_Bullet0;

	bool m_bActiveClass0;
	bool m_bActiveClass1;
	bool m_bActiveClass2;
	bool m_bActiveClass3;
	bool m_bActiveClass4;

	float m_nextFire0;
	float m_nextFire1;
	float m_nextFire2;
	float m_nextFire3;
	float m_nextFire4;


	//Shooter 관련
	int m_nShooter0Direction =0;
	int[] m_arrShooterDirection = {0, 45, 90, 135, 180, -135, -90, -45};

	// Use this for initialization
	void Start () 
	{
		m_rb = GetComponent<Rigidbody2D>();
		m_lineRenderer = GetComponent<LineRenderer>();
		//m_lineRenderer.startWidth = 0.05f;
		//m_llneRenderer.endWidth = 0.05f;
		//ValueController valueController = GameObject.Find("ValueObject").GetComponent<ValueController>(); 
		m_fPlayerMoveSpeed = StaticValueController.globalPlayer.MoveSpeed;
		m_fPlayerRotateSpeed = StaticValueController.globalPlayer.RotateSpeed;
		m_fShooter0Rate = StaticValueController.globalShooter0.Rate;
		m_fShooter0Distance = StaticValueController.globalShooter0.Distance;
		m_fBulletC0L01MoveSpeed =StaticValueController.globalBulletC0L01.MoveSpeed;
		m_stageController = GameObject.Find("GameControlObject").GetComponent<StageController>();
		m_bActiveClass0 = StaticValueController.globalManager.ActiveClass0;
		m_bActiveClass1 = StaticValueController.globalManager.ActiveClass1;
		m_bActiveClass2 = StaticValueController.globalManager.AcitveClass2;
		m_bActiveClass3 = StaticValueController.globalManager.ActiveClass3;
		m_bActiveClass4 = StaticValueController.globalManager.ActiveClass4;
		m_Bullet0 = (GameObject)Resources.Load("BulletC0L01");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//속도 조정
		// if( m_rb.velocity.x > m_fPlayerMoveSpeed )
		// 	m_rb.velocity.x = m_fPlayerMoveSpeed;
		//Debug.Log("Player Speed: " + m_rb.velocity);
		// if( m_rb.velocity.magnitude > 10 ) m_rb.velocity.magnitude = 10;
		//m_rb.AddRelativeForce(Vector2.up * m_fPlayerMoveSpeed, ForceMode2D.Impulse);
		//m_rb.velocity = transform.forward * m_fPlayerMoveSpeed;
		//Debug.Log("Player transform.forward: " + transform.forward);
		//Debug.Log("Player magnitude: " + m_rb.velocity.magnitude);

		//game이 pause 상태면 return;
		if( GameManagerController.Instance.getPause() == true) return;

		if( Input.GetMouseButtonDown(0))
		{
			stopPlayer();
			m_isPushPosition = false;
			dragPosition();
			m_isPushPosition = true;
		}

		if( Input.GetMouseButton(0))
		{
			if( m_isPushPosition)
			{
				//Debug.Log("Move");
				dragPosition();
			}
		}

		if( Input.GetMouseButtonUp(0))
		{
			if( m_isPushPosition)
			{
				m_isPushPosition = false;
				//movePlayer( vDirection);
				m_lineRenderer.SetPosition(0, Vector3.zero);
 				m_lineRenderer.SetPosition(1, Vector3.zero);
				m_stageController.StageAction();
			}
		}

		//두번째 버튼이 클릭되면 원점으로 되돌리기
		if( Input.GetMouseButton(1))
		{
			if( m_isPushPosition)
			{
				m_isPushPosition = false;
				m_lineRenderer.SetPosition(0, Vector3.zero);
 				m_lineRenderer.SetPosition(1, Vector3.zero);
			}
		}

		if( m_stageController != null && m_stageController.getRunning())
		{
			actionShooter();
		}
	}

	void dragPosition()
	{
		m_vMousePosition = Input.mousePosition;
		m_vMousePosition.z = 0;
		m_vMousePosition = Camera.main.ScreenToWorldPoint (m_vMousePosition);

		Vector2 vDirection = m_vMousePosition - transform.position;
		m_vDirection = vDirection / vDirection.magnitude;
		
		//선도선 그리고
		m_lineRenderer.SetPosition(0, m_rb.position);
		m_lineRenderer.SetPosition(1, m_vMousePosition);
	}


	public void movePlayer()
	{
		 m_rb.AddForce( m_vDirection * m_fPlayerMoveSpeed);
		 Debug.Log("Player vDirection: " + m_vDirection + " * Speed:" + m_fPlayerMoveSpeed);
		 m_rb.angularVelocity = m_fPlayerRotateSpeed;
	}

	public void stopPlayer()
	{
		if( m_rb != null)
		{
			m_rb.velocity = Vector3.zero;
			m_rb.angularVelocity = 0f; 
		}

	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if(collision.gameObject.tag == "Block")
		{
            Destroy( collision.gameObject);
        }

		if(collision.gameObject.tag == "BlackHole")
		{
			m_stageController.StageReady();
		}
      
    }

	public void actionShooter()
	{
        if( m_bActiveClass0) { actionShooter0();}
    	if( m_bActiveClass1) { actionShooter1();};
		if( m_bActiveClass2) { actionShooter2();};
		if( m_bActiveClass3) { actionShooter3();};
		if( m_bActiveClass4) { actionShooter4();};
	}

	void actionShooter0()
	{
		//Shooter0 시작
		if (Time.time > m_nextFire0)
		{
			m_nextFire0 = Time.time + m_fShooter0Rate;
			Quaternion rotation = Quaternion.identity;
			rotation.eulerAngles = new Vector3(0, 0, m_arrShooterDirection[m_nShooter0Direction]); 
			GameObject gameObject = Instantiate(m_Bullet0, m_rb.transform.position,  rotation);
			BulletController bulletController = (BulletController)(gameObject.GetComponent<BulletController>());
			bulletController.initBullet(m_fBulletC0L01MoveSpeed, m_fShooter0Distance);
			//다음 방향
			m_nShooter0Direction++;
			if( m_nShooter0Direction >= m_arrShooterDirection.Length) m_nShooter0Direction = 0;
			//Debug.Log("Fire:" + m_nextFire);
		}
	}

	void actionShooter1()
	{

	}

	void actionShooter2()
	{
		
	}

	void actionShooter3()
	{
		
	}

	void actionShooter4()
	{
		
	}



}
