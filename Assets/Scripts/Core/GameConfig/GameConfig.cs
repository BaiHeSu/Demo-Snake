using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace snake
{
    public class GameConfig : MonoBehaviour
    {
        private static GameConfig instance;

        public static GameConfig Instance
        {
            get { return instance; }
        }

        // 地图大小
        [HideInInspector]
        public int mapHeight;
        [HideInInspector]
        public int mapWidth;
        public float timer;
        private void Awake()
        {
            instance = this;
            mapHeight = 18;
            mapWidth = 34;
            timer = 0.2f;
        }

        private void OnDestroy()
        {
            instance = null;
        }
    }
}