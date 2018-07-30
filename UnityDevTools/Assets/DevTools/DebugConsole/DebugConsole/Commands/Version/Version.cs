using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace UnityDevTools.Console
{
    internal class Version : MonoBehaviour
    {
        public const string VersionCommand = "version";

        public static void PrintVersion(string command)
        {
            if (command == VersionCommand)
            {
                Debug.Log("PlayerSettings.bundleVersion:= " + PlayerSettings.bundleVersion);
            }
        }
    }
}