using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour 
{

    void Awake()
    { 
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(540, 960, true); // true는 전체화면옵션
    }

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
