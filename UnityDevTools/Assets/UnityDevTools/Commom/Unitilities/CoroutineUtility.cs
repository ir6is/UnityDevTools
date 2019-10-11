using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// CoroutineUtility.
    /// </summary>
    public static class CoroutineUtility
    {
        public static IEnumerator LerpCoroutine(Action<float> action, float animationTime)
        {
            var startTime = Time.time;
            var endTime = startTime + animationTime;

            while (endTime >= Time.time)
            {
                yield return null;
                var currentPersent = (Time.time - startTime) / animationTime;
                action(currentPersent);
            }
        }
    }
}