using UnityEngine;
using UnityEngine.UI;

namespace UnityDevTools.Console
{
	public class Console : MonoBehaviour
	{

		#region data

		private const string ResourcePath = "Console";
		private static Console _instance;
		[SerializeField] private Button _openBtn, _closeLongConsoleBtn, _hideBtn, _closeConsole, _showConsoleBtn;

		#endregion

		#region interface

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

		public ShortConsole ConsoleClose { get; private set; }
		public LongConsole ConsoleOpen { get; private set; }

		#endregion

		#region monoBehaviour

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
			ConsoleClose = GetComponentInChildren<ShortConsole>(true);
			ConsoleClose.Initialize();

			ConsoleOpen = GetComponentInChildren<LongConsole>(true);
			ConsoleOpen.Initialize();
			ConsoleOpen.CommandRaised += HubScene.LoadHubScene;
			ConsoleOpen.CommandRaised += Version.PrintVersion;

			_openBtn.onClick.AddListener(() =>
			{
				ConsoleOpen.gameObject.SetActive(true);
				ConsoleClose.gameObject.SetActive(false);
			});

			_closeLongConsoleBtn.onClick.AddListener(() =>
			{
				ConsoleOpen.gameObject.SetActive(false);
				ConsoleClose.gameObject.SetActive(true);
			});

			_hideBtn.onClick.AddListener(() =>
			{
				ConsoleClose.gameObject.SetActive(false);
				_showConsoleBtn.gameObject.SetActive(true);
			});

			_closeConsole.onClick.AddListener(() =>
			{
				ConsoleClose.gameObject.SetActive(false);
			});

			_showConsoleBtn.onClick.AddListener(() =>
			{
				ConsoleClose.gameObject.SetActive(true);
				_showConsoleBtn.gameObject.SetActive(false);
			});
		}

		#endregion

		#region interface

		#endregion
	}
}
