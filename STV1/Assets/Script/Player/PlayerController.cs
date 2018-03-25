using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	float playerSpeedMove;
	float playerSpeedRotate;
	Rigidbody2D rb;
	// Use this for initialization
	Vector2 v2 = new Vector2(45, 45);  //방향  target.position - player.position;
	Vector2 playerVelocity;
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		SetValue setValue = GameObject.Find("SetValue").GetComponent<SetValue>(); 
		playerSpeedMove = setValue.globalSpeed.PlayerMove;
		playerSpeedRotate = setValue.globalSpeed.PlayerRotate;

		movePlayer();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate() 
	{
		
	}

	void movePlayer()
	{
		 rb.AddForce( new Vector2(45.0f,45.0f) * playerSpeedMove);
	}
}
