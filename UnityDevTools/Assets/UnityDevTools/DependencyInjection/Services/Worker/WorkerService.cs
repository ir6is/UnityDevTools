using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DI
{
    /// <summary>
    /// Implementation of <see cref="IWokrkerService"/>.
    /// </summary>
    public class WorkerService : IWokrkerService
    {
        #region data

        #endregion

        #region interface

        #endregion

        #region MonoBehaviour

        #endregion

        #region implementation

        #endregion
        public void DoImpotantWork()
        {
            Debug.Log("Work" +GetHashCode());
        }
    }
}