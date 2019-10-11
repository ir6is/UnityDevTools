using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Common
{
    public static class Vector3Utility
    {
        public static bool Approximately(Vector3 a, Vector3 b)
        {
            var result = true;

            for (int i = 0; i < 3; i++)
            {
                result = result && Mathf.Approximately(a[i], b[i]);
            }

            return result;
        }
    }
}