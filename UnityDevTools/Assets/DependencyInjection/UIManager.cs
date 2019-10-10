using System;
using System.Collections;
using System.Collections.Generic;
using UnityDI;
using UnityEngine;
using UnityEngine.UI;

namespace DI
{
    /// <summary>
    /// UIManager.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        #region data

        [SerializeField]
        private Canvas _canvas;
        [SerializeField]
        private View _btnPrefab;

        private IServiceProvider _container;

        #endregion

        #region interface

        public void Initialize(IServiceProvider container)
        {
            _container = container;
        }

        public TController CreateController<TController>(params object[] args)
        {
            var argsList = new List<object>(args);
            var view = Instantiate(_btnPrefab, _canvas.transform); // нашел вью
            argsList.Add(view);
            return (TController)ServiceProviderUtility.CreateInstance<TController>(_container, argsList.ToArray()); //activatorUtilities
        }

        #endregion

        #region MonoBehaviour

        #endregion

        #region implementation

        private void testc(Type type)
        {
            var s = type.GetGenericArguments();
            var d = typeof(Controller<int>).GetGenericArguments();
            Console.WriteLine();
        }

        #endregion
    }
}