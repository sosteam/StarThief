using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour 
{
	Rigidbody2D m_rb;
	float m_BulletSpeedMove;
	StageController m_stageController;

	// Use this for initialization
	void Start () 
	{
		m_rb = GetComponent<Rigidbody2D>();
		ValueController valueController = GameObject.Find("ValueObject").GetComponent<ValueController>();
		m_stageController = GameObject.Find("GameControlObject").GetComponent<StageController>();
		m_BulletSpeedMove = valueController.globalShooter.Shooter0Rate;
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
		m_rb.velocity = transform.up * m_BulletSpeedMove;
		Debug.Log(m_BulletSpeedMove);
	}

	public void Stop()
	{
			m_rb.velocity = Vector3.zero;
	}
}
