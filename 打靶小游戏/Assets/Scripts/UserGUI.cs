using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private GUIStyle style;
    private Circle mcircle;

    //控制规则显示
    bool isShow = false;
    //字体样式
    GUIStyle text_style = new GUIStyle();


    // Start is called before the first frame update
    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 20;
        mcircle = new Circle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 + 320, Screen.height / 2 - 180, 100, 100), "Score:" + ScoreRecorder.score, style);

        text_style.normal.textColor = new Color(0, 0, 0, 1);
        text_style.fontSize = 16;

        GUIStyle button_style = new GUIStyle("button")
		{
			fontSize = 15
		};

        if (GUI.Button(new Rect(10, 10, 60, 30), "Rule", button_style))
		{
			if (isShow)
				isShow = false;
			else
				isShow = true;
		}
		if(isShow)
		{
			GUI.Label(new Rect(Screen.width / 2 - 400 , 70, 100, 50), "直接点击靶子开始游戏", text_style);
			GUI.Label(new Rect(Screen.width / 2 - 400, 90, 250, 50), "游戏只有一轮", text_style);
			GUI.Label(new Rect(Screen.width / 2 - 400, 110, 250, 50), "越靠近中心的环分数越高", text_style);
            GUI.Label(new Rect(Screen.width / 2 - 400, 130, 250, 50), "加油！得到更高的分数", text_style);
		}
    }
}
