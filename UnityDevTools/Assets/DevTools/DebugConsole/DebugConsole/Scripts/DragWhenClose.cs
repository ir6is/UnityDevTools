using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityDevTools.Console
{
    public class DragWhenClose : MonoBehaviour, IDragHandler
    {
        private Transform _whatMooving;
        private void Awake()
        {
            _whatMooving = GetComponentInParent<ConsoleCloseController>().transform;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _whatMooving.position = eventData.position+ 
                (Vector2)_whatMooving.position- //поправка на смещение
                (Vector2)transform.position;
        }
    }
}