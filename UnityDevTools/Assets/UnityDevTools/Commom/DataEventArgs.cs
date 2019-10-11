using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// DataEventArgs.
    /// </summary>
    public class DataEventArgs<T> : EventArgs
    {
        public T Value { get; }

        public DataEventArgs(T value)
        {
            Value = value;
        }
    }
}