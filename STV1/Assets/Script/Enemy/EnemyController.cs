using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	Rigidbody2D m_rb;

    int     m_nEnemyCoin;
    int     m_nEnemyHealth;
    float   m_fEnemyMoveSpeed;
    int     m_nEnemyScore;

	StageController m_stageController;
	ValueController m_valueController;

	bool m_isStarDrag = false;
	GameObject m_Star;

	// Use this for initialization
	void Start () 
	{
		
		m_rb = GetComponent<Rigidbody2D>();
		m_stageController = GameObject.Find("GameControlObject").GetComponent<StageController>();
		if( gameObject.tag == "Enemy01")
		{
            m_nEnemyCoin = StaticValueController.globalEnemy01.Coin;
            m_nEnemyHealth = StaticValueController.globalEnemy01.Health;
            m_fEnemyMoveSpeed = StaticValueController.globalEnemy01.MoveSpeed;
            m_nEnemyScore = StaticValueController.globalEnemy01.Score;
		}
		if( gameObject.tag == "Enemy02")
		{
            m_nEnemyCoin = StaticValueController.globalEnemy02.Coin;
            m_nEnemyHealth = StaticValueController.globalEnemy02.Health;
            m_fEnemyMoveSpeed = StaticValueController.globalEnemy02.MoveSpeed;
            m_nEnemyScore = StaticValueController.globalEnemy02.Score;
		}

		//Debug.Log("Enemy tag:" + this.gameObject.tag);
		//Debug.Log("m_EnemySpeed:" + m_EnemySpeed);
		//m_rb.velocity = transform.up * m_Enemy01SpeedMove;
		//Debug.Log("up:"+ transform.up + " EenmySpeed:" + m_Enemy01SpeedMove);
	}

	void FixedUpdate() 
	{
		if( m_stageController.getRunning())
		{
			Move();

			if( m_isStarDrag )
        		m_Star.transform.position = transform.position;
		}
		else
		{
			Stop();
		}
	}

	public void Move(/*Vector2 vDirection*/)
	{
        m_rb.velocity = transform.up * m_fEnemyMoveSpeed;
	}

	public void Stop()
	{
			m_rb.velocity = Vector3.zero;
			m_rb.angularVelocity = 0f; 
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if( other.tag.StartsWith("Star") && m_isStarDrag == false)
		{
			m_Star = other.gameObject;
			//Debug.Log("m_StarGrab:" + m_isStarDrag);
			m_isStarDrag = true;
		}

		if( other.tag.StartsWith("Bullet"))
		{
			//Debug.Log("Bullet Trigger:" + other.tag);
			int nDamage = 0;
			if( other.tag == "BulletC0L01")
			{
                nDamage = StaticValueController.globalBulletC0L01.Damage;
			}
			m_nEnemyHealth = m_nEnemyHealth - nDamage;

			if( m_nEnemyHealth <= 0) // Destroy
			{
                GameManagerController.Instance.addScore( StaticValueController.globalEnemy01.Score);
                GameManagerController.Instance.addCoin(StaticValueController.globalEnemy01.Coin);
				Destroy( gameObject);
			}
		}
	}

}
