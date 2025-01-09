using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace snake
{
    public class StartPanel : MonoBehaviour
    {
        [SerializeField]
        private Button btnStart;
        private Button btnSetting;

        private void Start()
        {
            btnStart.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("PlayerScene");
            });
        }
    }

}
