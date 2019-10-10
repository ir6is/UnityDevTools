using System;
using System.Collections.Generic;

namespace UnityDI
{
    public interface IObjectProvider
    {
        object GetObject(params object[] args);
    }
}