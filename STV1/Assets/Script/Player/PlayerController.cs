using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	float m_playerSpeedMove;
	float m_playerSpeedRotate;
	StageController m_stageController;
	Rigidbody2D m_rb;
	Vector2 m_vDirection;

	// Use this for initialization
	void Start () 
	{
		m_rb = GetComponent<Rigidbody2D>();
		SetValue setValue = GameObject.Find("SetValue").GetComponent<SetValue>(); 
		m_playerSpeedMove = setValue.globalSpeed.PlayerMove;
		m_playerSpeedRotate = setValue.globalSpeed.PlayerRotate;
		m_stageController = GameObject.FindWithTag("GameController").GetComponent<StageController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetMouseButton(0))
		{
			Vector3 vMousePosition = Input.mousePosition;
			vMousePosition.z = 0;
			vMousePosition = Camera.main.ScreenToWorldPoint (vMousePosition);

			Vector2 vDirection = vMousePosition - transform.position;
			m_vDirection = vDirection / vDirection.magnitude;

			//movePlayer( vDirection);
			m_stageController.StageAction();
		}
	}

	void FixedUpdate() 
	{
		 
	}

	void movePlayer()
	{
		 m_rb.AddForce( m_vDirection * m_playerSpeedMove);
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
