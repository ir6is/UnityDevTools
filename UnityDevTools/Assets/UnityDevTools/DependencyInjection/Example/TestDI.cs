using UnityDevTools.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityUnityDevTools.DependencyInjection;
using UnityEngine;

namespace YourNamespace
{
    /// <summary>
    /// TestUnityDevTools.DependencyInjection.
    /// </summary>
    public class DI : MonoBehaviour
    {
        Container container;
        private void Awake()
        {
            container = new Container();

            container.RegisterSingleton<IWokrkerService , WorkerService>();
            container.RegisterType<IDoubleWorker, DoubleWorkerService >();

            var test = container.GetService<IDoubleWorker>();

            test.DoubleWork();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {

                var test = container.GetService<IDoubleWorker>();

                test.DoubleWork();
            }
        }
    }
}