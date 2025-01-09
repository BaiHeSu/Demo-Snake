using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace snake
{
    public class GamePanel : MonoBehaviour
    {
        private static GamePanel instance;
        public static GamePanel Instance
        {
            get { return instance; }
        }
        
        [SerializeField] private Transform tScore;
        [SerializeField] private Transform tFoodCount;
        private TMP_Text txtScore;
        private TMP_Text txtFoodCount;
        
        private int foodCount;

        public int FoodCount
        {
            get
            {
                return foodCount;
            }
            set
            {
                if (foodCount != value)
                {
                    foodCount = value;
                    OnChangeFoodCount();
                }
            }
        }
        
        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            foodCount = 0;
            txtScore = tScore.gameObject.GetComponent<TMP_Text>();
            txtFoodCount = tFoodCount.gameObject.GetComponent<TMP_Text>();
            txtScore.text = $"得分：{FoodCount * 100}";
            txtFoodCount.text = $"食物：{FoodCount}";
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // todo : 玩家停止运动
                PausePanel.Instance.gameObject.SetActive(true);
                Player.Instance.Pause();
            }
        }

        private void OnDestroy()
        {
            instance = null;
        }

        public void OnChangeFoodCount()
        {
            txtScore.text = $"得分：{FoodCount * 100}";
            txtFoodCount.text = $"食物：{FoodCount}";
        }
    }
}

