using DI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityDI;
using UnityEngine;
namespace YourNamespace
{
    /// <summary>
    /// TestDI.
    /// </summary>
    public class TestDI : MonoBehaviour
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