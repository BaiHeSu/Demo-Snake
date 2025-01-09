using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace snake
{
    public class FailPanel : MonoBehaviour
    {
        private static FailPanel instance;
        public static FailPanel Instance
        {
            get { return instance; }
        }
        
        [SerializeField] private Button btnReStart;
        [SerializeField] private Button btnExit;

        private void Awake()
        {
            instance = this;
            gameObject.SetActive(false);
        }

        private void Start()
        {
            btnReStart.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("PlayerScene");
            });
            btnExit.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("StartScene");
            });
        }
        
        private void OnDestroy()
        {
            instance = null;
        }
    }
}

