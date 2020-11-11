﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction
{
    DiskFactory diskFactory;                         //飞碟工厂
    RoundController roundController;
    UserGUI userGUI;

    void Start()
    {
        SSDirector.GetInstance().CurrentScenceController = this;
        gameObject.AddComponent<DiskFactory>();
        gameObject.AddComponent<CCActionManager>();
        gameObject.AddComponent<PhysisActionManager>();
        gameObject.AddComponent<RoundController>();
        gameObject.AddComponent<UserGUI>();
        LoadResources();
    }

    public void LoadResources()
    {
        diskFactory = Singleton<DiskFactory>.Instance;
        roundController = Singleton<RoundController>.Instance;
        userGUI = Singleton<UserGUI>.Instance;
    }

    public void Hit(Vector3 position)
    {
        Camera ca = Camera.main;
        Ray ray = ca.ScreenPointToRay(position);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.collider.gameObject.GetComponent<DiskData>() != null)
            {
                //击中后操作、计分
                hit.collider.gameObject.transform.position = new Vector3(0, -7, 0);
                roundController.Record(hit.collider.gameObject.GetComponent<DiskData>());
                userGUI.SetPoints(roundController.GetPoints());
            }
        }
    }

    public void Restart()
    {
        userGUI.SetMessage("");
        userGUI.SetPoints(0);
        roundController.Reset();
    }

    public float GetScore() 
    {
        return roundController.GetPoints();
    }

    public int GetRound()
    {
        return roundController.GetRound();
    }

    public void SetFlyMode(bool isPhysis)
    {
        roundController.SetFlyMode(isPhysis);
    }

    public void FreeDisk(GameObject disk)
    {
        diskFactory.FreeDisk(disk);
    }

    void Update()
    {
    }
}
