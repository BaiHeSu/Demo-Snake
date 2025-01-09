using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
        var randomX = Random.Range(-GameConfig.Instance.mapWidth / 2, GameConfig.Instance.mapWidth / 2);
        var randomY = Random.Range(-GameConfig.Instance.mapHeight / 2, GameConfig.Instance.mapHeight / 2);
        var cache = Instantiate(foodPerfab,new Vector3(randomX,randomY,0),quaternion.identity);
        cache.GetComponent<SpriteRenderer>().sprite = foodSprites[Random.Range(0, foodSprites.Count)];
        cache.transform.parent = transform.parent;
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
