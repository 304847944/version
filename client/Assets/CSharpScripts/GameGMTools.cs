﻿using UnityEngine;
using System.Collections;
using System.IO;

public class GameGMTools : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		var data =PlayerPrefs.GetString ("GM");
		if(!string.IsNullOrEmpty(data))
		  level = data; 
        green.alignment = TextAnchor.MiddleRight;
        green.normal.textColor = Color.green;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	private string level = "level 1";

    GUIStyle green = new GUIStyle();
	public void OnGUI ()
	{
		GUI.Box (new Rect (Screen.width - 300, Screen.height - 50, 300, 50), "GM Tools");
        GUI.Label(new Rect(Screen.width- 220,5, 200,40),
            string.Format("FPS:{0:0}P:{1:0}\nS:{2:0.00}kb/s R:{3:0.00}kb/s(AVG)", 
                1/Time.deltaTime,
                UAppliaction.Singleton.PingDelay,
                (UAppliaction.Singleton.SendTotal/1024.0f)/Mathf.Max(1,Time.time - UAppliaction.Singleton.ConnectTime),
                (UAppliaction.Singleton.ReceiveTotal/1024.0f)/Mathf.Max(1,Time.time - UAppliaction.Singleton.ConnectTime))
            ,green );
		GUI.BeginGroup (new Rect (Screen.width - 295, Screen.height - 30, 285, 25));

		GUILayout.BeginHorizontal ();
        level = GUILayout.TextField (level,GUILayout.Width(160));
		if (GUILayout.Button ("GM",GUILayout.Width (60))) {
			StartGM (level);
		}
        if (GUILayout.Button("Exit", GUILayout.Width(60)))
        {
            UAppliaction.Singleton.ChangeGate(null);

        }
		GUILayout.EndHorizontal ();
		GUI.EndGroup ();
	}

	private void StartGM(string gm)
	{

		var args = gm.Split (' ');
		if (args.Length >= 2) {
			switch (args [0].ToLower()) 
            {
                case "replay":
                    {
                        var data = File.ReadAllBytes(Path.Combine(Application.dataPath, "replay.data"));
                        var gate = new UReplayGate(data, 1);
                        UAppliaction.Singleton.ChangeGate(gate);
                    }
                    break;
                case "server":
                    {
                        var index =  int.Parse (args[1]);
                        UAppliaction.Singleton.index = index;
                        UAppliaction.Singleton.GetServer();
                        UAppliaction.Singleton.GotoLoginGate();
                    }
                    break;
			default:
				return;
				//break;
            }
		}

		PlayerPrefs.SetString ("GM", gm);
	}
}
