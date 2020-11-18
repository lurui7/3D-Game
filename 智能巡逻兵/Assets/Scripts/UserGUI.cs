using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

    private IUserAction action;
    private GUIStyle score_style = new GUIStyle();
    private GUIStyle text_style = new GUIStyle();
    private GUIStyle over_style = new GUIStyle();
    
    //private bool game_start = false;
    //控制规则显示
    bool isShow = false;
    
    void Start ()
    {
        action = SSDirector.GetInstance().CurrentScenceController as IUserAction;
        text_style.normal.textColor = new Color(0, 0, 0, 1);
        text_style.fontSize = 16;
        score_style.normal.textColor = new Color(1,0,0,1);
        score_style.fontSize = 16;
        over_style.fontSize = 25;
    }

    public class Diretion {
        public const int UP = 0;
        public const int DOWN = 2;
        public const int LEFT = -1;
        public const int RIGHT = 1;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            action.MovePlayer(Diretion.UP);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            action.MovePlayer(Diretion.DOWN);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            action.MovePlayer(Diretion.LEFT);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            action.MovePlayer(Diretion.RIGHT);
        }
    }
    
    private void OnGUI()
    {   
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
			GUI.Label(new Rect(Screen.width / 2 - 400 , 70, 100, 50), "按方向键移动", text_style);
            GUI.Label(new Rect(Screen.width / 2 - 400 , 90, 150, 50), "成功躲避巡逻兵追捕加1分", text_style);
		}

        //if (game_start) {
            GUI.Label(new Rect(Screen.width - 150, 5, 200, 50), "分数:", text_style);
            GUI.Label(new Rect(Screen.width - 100, 5, 200, 50), action.GetScore().ToString(), score_style);

            if(action.GetGameover())
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.width / 2 - 250, 100, 100), "游戏结束", over_style);
                if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.width / 2 - 200, 100, 50), "重新开始"))
                {
                    action.Restart();
                    return;
                }
            }
        //}
        // else {
        //     GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 100), "智能巡逻兵", over_style);
            
        //     if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 50), "开始游戏")) {
        //         game_start = true;
        //         action.Restart();
        //     }
        // }
        
        
    }
}
