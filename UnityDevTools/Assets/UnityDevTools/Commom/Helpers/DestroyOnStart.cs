using UnityEngine;

namespace Common
{
    /// <summary>
    /// DestroyOnStart.
    /// </summary>
    public class DestroyOnStart : MonoBehaviour
    {
        private void Awake()
        {
            Destroy(gameObject);
        }
    }
}