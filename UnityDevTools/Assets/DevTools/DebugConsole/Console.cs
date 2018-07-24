using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

namespace UnityDevTools.Console
{
    public class Console : MonoBehaviour
    {
        public const string ResourcePath = "Console"; 
         
        public ConsoleCloseController ConsoleClose { get; private set; }
        public ConsoleOpenController ConsoleOpen { get; private set; }

        [SerializeField] private Button _openBtn,_closeBtn; 
  
        private static Console _instance; 
     
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                DestroyImmediate(gameObject);
                return;
            }
            ConsoleClose = GetComponentInChildren<ConsoleCloseController>();
            ConsoleClose.Initialize();
            ConsoleOpen = GetComponentInChildren<ConsoleOpenController>();
            ConsoleOpen.Initialize();

            _openBtn.onClick.AddListener(OnBtnOpenClick);
            _closeBtn.onClick.AddListener(OnBtnCloseClick);

            OnBtnCloseClick();
        }

        
         
        #region Handlers
        

        public void OnBtnCloseClick()
        {
            ConsoleOpen.gameObject.SetActive(false);
            ConsoleClose.gameObject.SetActive(true);
        }

        public void OnBtnOpenClick()
        {
            ConsoleOpen.gameObject.SetActive(true);
            ConsoleClose.gameObject.SetActive(false);
        } 
        #endregion
         
        public static Console Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Instantiate(Resources.Load<Console>(ResourcePath));
                    _instance.name = _instance.name.Replace("(Clone)", "");
                }
                return _instance;
            }
        }  
    }
}
