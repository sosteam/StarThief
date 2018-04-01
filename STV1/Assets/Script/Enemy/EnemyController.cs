using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	Rigidbody2D m_rb;
	float m_Enemy01SpeedMove;
	StageController m_stageController;
	// Use this for initialization
	void Start () 
	{
		
		m_rb = GetComponent<Rigidbody2D>();
		ValueController valueController = GameObject.Find("ValueObject").GetComponent<ValueController>();
		m_stageController = GameObject.Find("GameControlObject").GetComponent<StageController>();
		m_Enemy01SpeedMove = valueController.globalSpeed.Enemy01Move;
		//m_rb.velocity = transform.up * m_Enemy01SpeedMove;
		//Debug.Log("up:"+ transform.up + " EenmySpeed:" + m_Enemy01SpeedMove);
	}

	void FixedUpdate() 
	{
		if( m_stageController.getRunning())
		{
			Move();
		}
		else
		{
			Stop();
		}
	}
	
	public void Move(/*Vector2 vDirection*/)
	{
		m_rb.velocity = transform.up * m_Enemy01SpeedMove;
	}

	public void Stop()
	{
			m_rb.velocity = Vector3.zero;
			m_rb.angularVelocity = 0f; 
	}
}
