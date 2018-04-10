using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour 
{
	Rigidbody2D m_rb;
	float m_fBulletMoveSpeed;
	float m_fBulletDistance;
	StageController m_stageController;
	Vector3 m_vStartPosition;

	// Use this for initialization
	void Start () 
	{
		m_rb = GetComponent<Rigidbody2D>();
		m_stageController = GameObject.Find("GameControlObject").GetComponent<StageController>();
		m_vStartPosition = transform.position;//출발 위치 기록
	}
	
	void FixedUpdate() 
	{
		if(m_stageController != null && m_stageController.getRunning())
		{
			moveBullet();
		}
	}

	void Update() 
	{
		if( m_stageController.getRunning())
		{
			destroyBullet();
		}
	}

	void moveBullet(/*Vector2 vDirection*/)
	{
		m_rb.velocity = transform.up * m_fBulletMoveSpeed;
		//Debug.Log(m_BulletSpeedMove);
	}

	void destroyBullet()
	{
		//Debug.Log("m_vStartPosition:" + m_vStartPosition);

		if( Vector3.Distance(transform.position, m_vStartPosition) > m_fBulletDistance)
		{
			if( gameObject != null)	Destroy(gameObject);
		} 
	}

	public void initBullet(float fMoveSpeed, float fDistance)
	{
		m_fBulletMoveSpeed = fMoveSpeed;
		m_fBulletDistance = fDistance;
		
	}
}
