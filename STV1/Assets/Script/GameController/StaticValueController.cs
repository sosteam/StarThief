using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScreen
{
    public static float ScreenX;
    public static float ScreenY;
    public static int   BlockCountX;
    public static int   BlockCountY;
    public static float BlockSizeX;
    public static float BlockSizeY;
}

public class GlobalManager
{
    public static bool      ActiveClass0;
    public static bool      ActiveClass1;
    public static bool      AcitveClass2;
    public static bool      ActiveClass3;
    public static bool      ActiveClass4;
}

public class GlobalPlayer
{
    public static float     MoveSpeed;
    public static float     RotateSpeed;
    public static float     Shooter0Rate;
}

public class GlobalShooter
{
    public float Direction;
    public float Distance;
    public float Rate;
}

public class GlobalETC
{
    public float    BlackHoleRadius;
}

public class GlobalEnemy
{
    public int      Coin;
	public int		Health;
	public float	MoveSpeed;
	public int	    Score;
}

public class GlobalBullet
{
    public int      Damage;
    public float    MoveSpeed;
}

public class StaticValueController : MonoBehaviour 
{
    public static GlobalScreen  globalScreen;
    public static GlobalManager globalManager;
    public static GlobalPlayer  globalPlayer;
    public static GlobalShooter globalShooter0;
    public static GlobalShooter globalShooter1;
    public static GlobalShooter globalShooter2;
    public static GlobalShooter globalShooter3;
    public static GlobalShooter globalShooter4;

    public static GlobalETC     globalETC;
	public static GlobalEnemy   globalEnemy01;
	public static GlobalEnemy   globalEnemy02;
    public static GlobalBullet  globalBulletC0L01;

    void Awake()
    {
        setValue();
    }

	// Use this for initialization
	void Start () 
	{
		
	}

	void setValue()
	{
        globalScreen.ScreenX = 11.2f;
        globalScreen.ScreenY = 20.0f;
        globalScreen.BlockCountX = 10;
        globalScreen.BlockCountY = 24;
        globalScreen.BlockSizeX = 1.12f;
        globalScreen.BlockSizeY = 0.825f;

        globalManager.ActiveClass0 = true;
        globalManager.ActiveClass1 = false;
        globalManager.AcitveClass2 = false;
        globalManager.ActiveClass3 = false;
        globalManager.ActiveClass4 = false;

        globalPlayer.MoveSpeed = 0.3f;
        globalPlayer.RotateSpeed = 90;

        globalShooter0.Distance = 5.0f;
        globalShooter0.Rate = 0.25f;

        globalETC.BlackHoleRadius = 1.5f;
        
		globalEnemy01.Coin = 10;
		globalEnemy01.Health = 8;
		globalEnemy01.MoveSpeed = 0.2f;
		globalEnemy01.Score = 10;

		globalEnemy02.Coin = 20;
		globalEnemy02.Health = 8;
		globalEnemy02.MoveSpeed = 2.0f;
		globalEnemy02.Score = 20;

        globalBulletC0L01.Damage = 8;
        globalBulletC0L01.MoveSpeed = 5.0f;
	}
	
}
