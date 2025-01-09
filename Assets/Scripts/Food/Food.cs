using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
#if UNITY_EDITOR 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FoodGenerator.Instance?.GenerateFood();
            Destroy(gameObject);
        }
    }
#endif
    
}
