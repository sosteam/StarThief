﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	float m_playerSpeedMove;
	float m_playerSpeedRotate;
	StageController m_stageController;
	Rigidbody2D m_rb;
	Vector3 m_vMousePosition;
	Vector2 m_vDirection;
	LineRenderer m_lineRenderer;
	bool m_isPushPosition = false;
	float m_Shooter0Rate;
	GameObject m_Bullet0;
	float m_nextFire;

	// Use this for initialization
	void Start () 
	{
		m_rb = GetComponent<Rigidbody2D>();
		m_lineRenderer = GetComponent<LineRenderer>();
		//m_lineRenderer.startWidth = 0.05f;
		//m_llneRenderer.endWidth = 0.05f;
		ValueController valueController = GameObject.Find("ValueObject").GetComponent<ValueController>(); 
		m_playerSpeedMove = valueController.globalSpeed.PlayerMove;
		m_playerSpeedRotate = valueController.globalSpeed.PlayerRotate;
		m_Shooter0Rate = valueController.globalShooter.BulletSpeed;
		m_stageController = GameObject.Find("GameControlObject").GetComponent<StageController>();
		m_Bullet0 = GameObject.Find("BulletC0L01");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetMouseButtonDown(0))
		{
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
		 m_rb.AddForce( m_vDirection * m_playerSpeedMove);
		 m_rb.angularVelocity = m_playerSpeedRotate;
	}

	public void stopPlayer()
	{
		if( m_rb != null)
		{
			m_rb.velocity = Vector3.zero;
			m_rb.angularVelocity = 0f; 
		}

	}

	public void actionShooter()
	{
		if( m_stageController.getRunning())
		{
			//Shooter0 시작
			if (Time.time > m_nextFire)
			{
				m_nextFire = Time.time + m_Shooter0Rate;
				Instantiate(m_Bullet0, m_rb.transform.position,  m_rb.transform.rotation);
			}
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
}
