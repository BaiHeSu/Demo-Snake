using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace snake
{
    public class PausePanel : MonoBehaviour
    {
        private static PausePanel instance;
        public static PausePanel Instance
        {
            get { return instance; }
        }

        [SerializeField] private Button btnResume;
        [SerializeField] private Button btnReStart;
        [SerializeField] private Button btnExit;

        private void Awake()
        {
            instance = this;
            gameObject.SetActive(false);
        }

        private void Start()
        {
            btnResume.onClick.AddListener(() =>
            {
                Player.Instance.Resume();
                gameObject.SetActive(false);
            });
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