using UnityUnityDevTools.DependencyInjection;
using UnityEngine;

namespace UnityDevTools.DependencyInjection
{
    /// <summary>
    /// ApplicationRoot.
    /// </summary>
    public class ApplicationRoot : MonoBehaviour
    {
        #region data

        [SerializeField]
        private UIManager _uiManager;

        #endregion

        #region interface

        #endregion

        #region MonoBehaviour
        private void Awake()
        {
            SetupContainer();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _uiManager.CreateController<ConctriteController>(1);
            }
        }
        #endregion

        #region implementation

        private void SetupContainer()
        {
            var container = new Container();

            container.RegisterSingleton<IWokrkerService, WorkerService>().RegisterType<IDoubleWorker, DoubleWorkerService>();
            _uiManager.Initialize(container);
        }

        #endregion
    }
}