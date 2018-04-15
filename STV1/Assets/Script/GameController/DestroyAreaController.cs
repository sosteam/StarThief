using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAreaController : MonoBehaviour 
{
	void OnTriggerExit2D(Collider2D other) 
	{
		if( other.tag.StartsWith("Star"))
		{
			Destroy(other.gameObject);
			GameManagerController.Instance.checkStarCount();
		}

		if( other.tag.StartsWith("Bullet")) Destroy(other.gameObject);

		if( other.tag.StartsWith("Enemy")) Destroy(other.gameObject);
		
	}

}
