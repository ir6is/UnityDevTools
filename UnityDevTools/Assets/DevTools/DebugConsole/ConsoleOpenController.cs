using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace UnityDevTools.Console
{
    public class ConsoleOpenController : MonoBehaviour
    {

        /// <summary>
        /// Max lenght _contentText.text view
        /// </summary>
        public const int MaxCharAmount = 16000;
        public event Action<string> CommandsHendlers;

        [Tooltip("Logs settings")]
        [SerializeField] private LogViewSettings[] _logViewSettings = new LogViewSettings[1];

        [Tooltip("Ui content viewer when console open")]
        [SerializeField] private Text _uiContentTextOpen;
        [SerializeField] private InputField _executeInputField;

        [SerializeField] private Button _executeBtn, _clearLog;

        private Queue<string> _logDebugMessages;
        private StringBuilder _messageBuilder;

        public void Initialize()
        {
            _logDebugMessages = new Queue<string>();
            _messageBuilder = new StringBuilder();
            _messageBuilder.Capacity = MaxCharAmount;
            Application.logMessageReceived += OnLogReceived;

            _executeBtn.onClick.AddListener(OnExecuteClick);
            _clearLog.onClick.AddListener(OnClearLogClick);
        }

        #region BtnHandlers
        private void OnClearLogClick()
        {
            _uiContentTextOpen.text = string.Empty;
            _logDebugMessages.Clear();
        }

        private void OnExecuteClick()
        {
            if (CommandsHendlers != null)
            {
                CommandsHendlers(_executeInputField.text);
            }
        }
        #endregion

        private void OnLogReceived(string condition, string stackTrace, LogType type)
        {
            foreach (LogViewSettings currLogViewSettings in _logViewSettings)
            {
                if (currLogViewSettings.Type == type)
                {
                    string newMessage = string.Format("<color=#{0}>{1}</color>\n",
                        ColorUtility.ToHtmlStringRGB(currLogViewSettings.TextColor),
                        condition);

                    if (currLogViewSettings.ShowStack)
                    {
                        newMessage += string.Format("<size={0}><color=#{1}>------\n{2}------\n</color></size>",
                            _uiContentTextOpen.fontSize * 0.75f,
                            ColorUtility.ToHtmlStringRGB(currLogViewSettings.TextColor), stackTrace);
                    }
                    _logDebugMessages.Enqueue(newMessage);

                    int unvisibelMessageCount = 0;
                    _messageBuilder.Length = 0;

                    //Заполнение видымых месседжей
                    foreach (var item in _logDebugMessages)
                    {
                        if (_messageBuilder.Length + item.Length < MaxCharAmount)
                        {
                            unvisibelMessageCount++;
                            _messageBuilder.Append(item);
                        }
                        else
                        {
                            break;
                        }
                    }

                    for (int i = 0; i < _logDebugMessages.Count - unvisibelMessageCount; i++)
                    {
                        _logDebugMessages.Dequeue();
                    }

                    _uiContentTextOpen.text = _messageBuilder.ToString();
                }
            }
        }
        [Serializable]
        private class LogViewSettings
        {
            public LogType Type = LogType.Log;
            public Color TextColor = Color.white;
            public bool ShowStack = false;
        }
    }
}