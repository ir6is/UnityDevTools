﻿using UnityDevTools.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityDevTools.DependencyInjection
{
    /// <summary>
    /// Controller.
    /// </summary>
    public class Controller<TView>
    {
        #region data

        #endregion

        #region interface
        protected TView View { get;private set; }
        public Controller(TView view)
        {
            View = view;
        }

        #endregion

        #region implementation

        #endregion
    }
}