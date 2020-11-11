using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    IUserAction userAction;
    string gameMessage;
    int points;
    GUIStyle text_style = new GUIStyle();
    GUIStyle bold_style = new GUIStyle();
    GUIStyle over_style = new GUIStyle();

    //控制规则显示
    bool isShow = false;

    private bool game_start = false;

    public void SetMessage(string gameMessage)
    {
        this.gameMessage = gameMessage;
    }

    public void SetPoints(int points)
    {
        this.points = points;
    }


    void Start()
    {
        points = 0;
        gameMessage = "";
        userAction = SSDirector.GetInstance().CurrentScenceController as IUserAction;
    }

    void OnGUI()
    {
        //小字体初始化
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 30;

        //大字体初始化
        GUIStyle bigStyle = new GUIStyle();
        bigStyle.normal.textColor = Color.white;
        bigStyle.fontSize = 50;

        text_style.normal.textColor = new Color(0, 0, 0, 1);
        text_style.fontSize = 16;
        bold_style.normal.textColor = new Color(1, 0, 0);
        bold_style.fontSize = 16;
        over_style.normal.textColor = new Color(1, 0, 0);
        over_style.fontSize = 25;

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
			GUI.Label(new Rect(Screen.width / 2 - 400 , 70, 100, 50), "点击Start开始游戏", text_style);
			GUI.Label(new Rect(Screen.width / 2 - 400, 90, 250, 50), "游戏过程中鼠标左键为hit", text_style);
			GUI.Label(new Rect(Screen.width / 2 - 400, 110, 250, 50), "随着时间的推移，难度会上升", text_style);
            GUI.Label(new Rect(Screen.width / 2 - 400, 130, 250, 50), "上吧！！！", text_style);
		}

        if (GUI.Button(new Rect(20, 200, 100, 40), "运动学"))
        {
            userAction.SetFlyMode(false);
        }
        if (GUI.Button(new Rect(20, 250, 100, 40), "物理学"))
        {
            userAction.SetFlyMode(true);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            userAction.Hit(Input.mousePosition);
        }


        if (game_start) {

            GUI.Label(new Rect(Screen.width - 150, 5, 200, 50), "Score:"+ points, text_style);
            GUI.Label(new Rect(100, 5, 50, 50), "Round:" + userAction.GetRound().ToString(), text_style);

            if (userAction.GetRound() == 4 ) {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 100), "GAME OVER", over_style);
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 50, 50), "YOUR SCORE:   " + userAction.GetScore().ToString(), over_style);
                if (GUI.Button(new Rect(Screen.width / 2 - 20, Screen.height / 2, 100, 50), "RESTART")) {
                    userAction.Restart();
                    return;
                }
                //userAction.GameOver();
            }
        }
        else {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 100), "Hit UFO", over_style);
            
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 50), "START")) {
                game_start = true;
                userAction.Restart();
            }
        }
    }
}
