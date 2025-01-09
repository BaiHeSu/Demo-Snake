using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace snake
{
    public class FoodGenerator : MonoBehaviour
    {
        private static FoodGenerator instance;

        public static FoodGenerator Instance
        {
            get { return instance; }
        }
    
        [Header("食物图片")]
        public List<Sprite> foodSprites;
        [Header("食物预制体")]
        public GameObject foodPerfab;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            GenerateFood();
        }
    
        public void GenerateFood()
        {
            bool isValidPosition;
            float randomX, randomY;
            do
            {
                randomX = Random.Range(-GameConfig.Instance.mapWidth / 2, GameConfig.Instance.mapWidth / 2);
                randomY = Random.Range(-GameConfig.Instance.mapHeight / 2, GameConfig.Instance.mapHeight / 2);
                randomX += randomX >= 0 ? 0.5f : -0.5f; 
                randomY += randomY >= 0 ? 0.5f : -0.5f; 
                isValidPosition = !CheckValiadPosition(randomX,randomY);
            } while (isValidPosition);
            
            var cache = Instantiate(foodPerfab,new Vector3(randomX,randomY,0),quaternion.identity);
            cache.GetComponent<SpriteRenderer>().sprite = foodSprites[Random.Range(0, foodSprites.Count)];
            cache.transform.parent = transform.parent;
        }

        private bool CheckValiadPosition(float posX, float posY)
        {
            var foodInsPos = new Vector2(posX, posY);
            if (Player.Instance.transform.position.Equals(foodInsPos))
                return false;
            foreach (var item in Player.Instance.body)
            {
                if (item.position.Equals(foodInsPos))
                    return false;
            }
            return true;
        }

        private void OnDestroy()
        {
            instance = null;
        }
    }
}
