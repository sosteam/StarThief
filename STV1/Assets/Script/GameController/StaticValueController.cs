using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScreen
{
    public float ScreenX;
    public float ScreenY;
    public int   BlockCountX;
    public int   BlockCountY;
    public float BlockSizeX;
    public float BlockSizeY;
}

public class GlobalManager
{
    public bool      ActiveClass0;
    public bool      ActiveClass1;
    public bool      AcitveClass2;
    public bool      ActiveClass3;
    public bool      ActiveClass4;
}

public class GlobalPlayer
{
    public float     MoveSpeed;
    public float     RotateSpeed;
    public float     Shooter0Rate;
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
    public static GlobalScreen  globalScreen = new GlobalScreen();
    public static GlobalManager globalManager = new GlobalManager();
    public static GlobalPlayer  globalPlayer = new GlobalPlayer();
    public static GlobalShooter globalShooter0 = new GlobalShooter();
    public static GlobalShooter globalShooter1 = new GlobalShooter();
    public static GlobalShooter globalShooter2 = new GlobalShooter();
    public static GlobalShooter globalShooter3 = new GlobalShooter();
    public static GlobalShooter globalShooter4 = new GlobalShooter();

    public static GlobalETC     globalETC = new GlobalETC();
	public static GlobalEnemy   globalEnemy01 = new GlobalEnemy();
	public static GlobalEnemy   globalEnemy02 = new GlobalEnemy();
    public static GlobalBullet  globalBulletC0L01 = new GlobalBullet();

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
