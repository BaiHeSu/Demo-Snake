using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace snake
{
    public class Player : MonoBehaviour
    {
        private static Player instance;
        public static Player Instance
        {
            get { return instance; }
        }
        private float timer;
        private Vector2 direction;
        private Vector2 directionCache;
        [Header("身体预制体")]
        public Transform bodyPerfab;
        public List<Transform> body = new List<Transform>();
        private Vector2 lastMovePosition;
        private void Awake()
        {
            direction = Vector2.right;
            directionCache = direction;
            instance = this;
        }

        private void Start()
        {
            timer = GameConfig.Instance.timer;
            InvokeRepeating("MoveSnake",0,timer);
        }

        private void Update()
        {
            ChangeMoveDirection();
            if (Input.GetKeyDown(KeyCode.G))
            {
                Grow();
            }
        }

        private void ChangeMoveDirection()
        {
            if (Input.GetKeyDown(KeyCode.W) && directionCache != Vector2.down) directionCache = Vector2.up;
            if (Input.GetKeyDown(KeyCode.A) && directionCache != Vector2.right) directionCache = Vector2.left;
            if (Input.GetKeyDown(KeyCode.S) && directionCache != Vector2.up) directionCache = Vector2.down;
            if (Input.GetKeyDown(KeyCode.D) && directionCache != Vector2.left) directionCache = Vector2.right;
            
        }

        private void Grow()
        {
            var cache = Instantiate(bodyPerfab, (Vector3)lastMovePosition, quaternion.identity);
            cache.parent = transform.parent;
            body.Add(cache);
        }
        
        private void MoveSnake()
        {
            SetLastMovePosition();
            if (body.Count != 0)
            {
                for (var i = body.Count - 1; i > 0; i--)
                {
                    body[i].position = body[i - 1].position;
                }
                body[0].position = transform.position;
            }
            if ((directionCache + direction).magnitude != 0)
                direction = directionCache;
            transform.position += (Vector3)direction;
        }

        private void SetLastMovePosition()
        {
            if (body.Count == 0)
            {
                lastMovePosition = transform.position;
            }
            else
            {
                lastMovePosition = body[body.Count - 1].position;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"trigger   {other.gameObject.name}");
            if (other.gameObject.CompareTag("Food"))
            {
                Destroy(other.gameObject);
                Grow();
                FoodGenerator.Instance.GenerateFood();
            }
        }

        private void OnDestroy()
        {
            instance = null;
        }
    }
}
