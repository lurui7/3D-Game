using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    private int count = 0;//统计当前步数
    private int[,] map = new int [3, 3];//地图
    public Texture2D img;
    //AudioSource win,lose;

    private void Start()
    {
        reset();
        //win = GetComponent<AudioSource>();
        //lose = GetComponent<AudioSource>();
    }

    private void reset()
    {
        for(int i = 0; i < 3; ++i){
            for(int j = 0; j < 3; ++j){
                map[i, j] = 0;
            }
        }
        count = 0;
    }

    void OnGUI()
    {
        GUIStyle temp1 = new GUIStyle{
            fontSize = 50
        };
        temp1.normal.textColor = Color.black;
        temp1.fontStyle = FontStyle.BoldAndItalic;

        GUIStyle temp2 = new GUIStyle();
        temp2.normal.background = img;
        GUI.Label (new Rect(0, 0, 800, 400), "", temp2);

        int winner = CheckWinner();
        if(winner == 1){
            GUI.Label(new Rect(275, 150, 100, 50), "You win!", style: temp1);//x win
            //lose.Stop();
            //win.Play();
        }
        else if(winner == 2){
            GUI.Label(new Rect(275, 150, 100, 50), "You lose!", style: temp1);//o win
            //win.Stop();
            //lose.Play();
        }
        else if(count == 9){
            GUI.Label(new Rect(275, 150, 100, 50), "No winner!", style: temp1);
            GUI.Label(new Rect(275, 200, 100, 50), "please start again!", style: temp1);
            //win.Stop();
            //lose.Stop();
        }
        else{
            for(int i = 0; i < 3; ++i){
                for(int j = 0; j < 3; ++j){
                    if(map[i, j] == 0){
                        if(GUI.Button(new Rect(100 + i * 50, 100 + j * 50, 50, 50), "")){
                            if(count % 2 == 0)  
                                map[i, j] = 1;
                            else   
                                map[i, j] = 2;
                            count += 1;
                        }
                    }
                    if(map[i, j] == 1){
                        GUI.Button(new Rect(100 + i * 50, 100 + j * 50, 50, 50), "X");
                    }
                    if(map[i, j] == 2){
                        GUI.Button(new Rect(100 + i * 50, 100 + j * 50, 50, 50), "O");
                    }
                }
            }  
        }

        if(GUI.Button(new Rect(125, 275, 100, 50), "Restart")){
            reset();
            //win.Stop();
            //lose.Stop();
        }
    }

    private int CheckWinner()
    {
        //for row
        for(int i = 0; i < 3; ++i){
            if(map[i, 0] != 0 && map[i, 0] == map[i, 1] && map[i, 0] == map[i, 2]){
                return map[i, 0];
            }
        }
        //for column
        for(int j = 0; j < 3; ++j){
            if(map[0, j] != 0 && map[0, j] == map[1, j] && map[0, j] == map[2, j]){
                return map[0, j];
            }
        }
        //for diagonal
        if(map[1, 1] != 0 && map[0, 0] == map[1, 1] && map[1, 1] == map[2, 2])
            return map[1, 1];
        if(map[1, 1] != 0 && map[2, 0] == map[1, 1] && map[1, 1] == map[0, 2])
            return map[1, 1];
        
        return 0;
    }
}
