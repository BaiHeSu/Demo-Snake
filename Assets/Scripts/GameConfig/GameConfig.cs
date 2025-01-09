using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    private static GameConfig instance;

    public static GameConfig Instance
    {
        get { return instance; }
    }

    // 地图大小
    public int mapHeight;
    public int mapWidth;
    private void Awake()
    {
        instance = this;
        mapHeight = 40;
        mapWidth = 80;
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
