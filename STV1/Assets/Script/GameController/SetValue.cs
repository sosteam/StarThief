using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalSpeed
{
	public float PlayerMove;
	public float PlayerRotate;
}

public class SetValue : MonoBehaviour 
{
	public GlobalSpeed globalSpeed;

}
