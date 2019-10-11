using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// TransformUtility.
    /// </summary>
    public static class TransformUtility
    {
        public static void CopyTransformFull(this Transform myTransform, Transform copyTransform)
        {
            myTransform.position = copyTransform.position;
            myTransform.rotation = copyTransform.rotation;
            myTransform.localScale = copyTransform.localScale;
        }
    }
}