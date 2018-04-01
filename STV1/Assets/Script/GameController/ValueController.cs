using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalScreen
{
	public float ScreenX = 11.2f;
	public float ScreenY = 20.0f;
	public float BlackHoleRadius = 1.5f;
	public int BlockCountX = 10;
	public int BlockCountY = 24;
	public float BlockSizeX = 1.12f;
	public float BlockSizeY = 0.825f;
}

[System.Serializable]
public class GlobalSpeed
{
	public float PlayerMove;
	public float PlayerRotate;
	public float Enemy01Move;
	public float Enemy02Move;
}
public class ValueController : MonoBehaviour 
{

	public GlobalSpeed globalSpeed;
	public GlobalScreen globalScreen;
}
