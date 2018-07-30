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
        private ConsoleHiddenController _consoleHidden;
        private static Console _instance;


        [SerializeField] private Button _openBtn, _closeBtn, _hideBtn;
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(_instance.gameObject);
            }
            else
            {
                DestroyImmediate(gameObject);
                return;
            }
            ConsoleClose = GetComponentInChildren<ConsoleCloseController>(true);
            ConsoleClose.Initialize();

            ConsoleOpen = GetComponentInChildren<ConsoleOpenController>(true);
            ConsoleOpen.Initialize();
            ConsoleOpen.CommandsHendlers += HubScene.LoadHubScene;
            ConsoleOpen.CommandsHendlers += Version.PrintVersion;

            _consoleHidden = GetComponentInChildren<ConsoleHiddenController>(true);
            _consoleHidden.Initialize(OnUnhide);

            _openBtn.onClick.AddListener(OnBtnOpenClick);
            _closeBtn.onClick.AddListener(OnBtnCloseClick);
            _hideBtn.onClick.AddListener(OnBtnHideClick);



            OnBtnHideClick();
        }
        private void OnUnhide()
        {
            OnBtnCloseClick();
        } 

        #region HandlersUi
        private void OnBtnCloseClick()
        {
            ConsoleOpen.gameObject.SetActive(false);
            ConsoleClose.gameObject.SetActive(true);
            _consoleHidden.gameObject.SetActive(false);
        } 
        private void OnBtnOpenClick()
        {
            ConsoleOpen.gameObject.SetActive(true);
            ConsoleClose.gameObject.SetActive(false);
        } 
        private void OnBtnHideClick()
        {
            _consoleHidden.gameObject.SetActive(true);
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
