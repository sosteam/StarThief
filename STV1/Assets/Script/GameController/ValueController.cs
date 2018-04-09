using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
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
*/

[System.Serializable]
public class GlobalSpeed
{
	public float PlayerMove;
	public float PlayerRotate;
	public float Enemy01Move;
	public float Enemy02Move;
}

[System.Serializable]
public class GlobalHealthDamage
{
	public int Enemy01Health = 1;
	public int Enemy02Health = 1;
	public int BulletC0L01Damage = 1;
}

/*
[System.Serializable]
public class GlobalShooter
{
	public float Shooter0Rate;
	public float Bullet0Distance;
	public float BulletSpeed;
}
*/

[System.Serializable]
public class GlobalBalance
{
	public int BlockCount;
	public int Enemy01Count;
	public int Enemy02Count;
}

public class ValueController : MonoBehaviour 
{
	public GlobalSpeed globalSpeed;
	public GlobalScreen globalScreen;
	public GlobalShooter globalShooter;
	public GlobalBalance globalBalance;
	public GlobalHealthDamage globalHealthDamage;
}
