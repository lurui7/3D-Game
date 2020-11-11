using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserAction
{
    void SetFlyMode(bool isPhysis);
    void Hit(Vector3 position);
    void Restart();
    float GetScore();
    int GetRound();
    //void GameOver();
}

public enum SSActionEventType : int { Started, Competed }
public interface ISSActionCallback
{
    //回调函数
    void SSActionEvent(SSAction source,
        SSActionEventType events = SSActionEventType.Competed,
        int intParam = 0,
        string strParam = null,
        Object objectParam = null);
}