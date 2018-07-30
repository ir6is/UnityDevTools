using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UnityDevTools.Console
{
    public class ConsoleHiddenController : MonoBehaviour, IDragHandler
    {
        private float _residueTime = 0;
        private Action _show;
        private Vector2 _idelPos;
        private RectTransform _rectTransform;
        private float _chachedRotationOrientation = 0;
        private void OnEnable()
        {
            StartCoroutine(CheckRotation());
        } 
        public void Initialize(Action show)
        {
            _show = show;
            _rectTransform = transform as RectTransform;
            Refresh();
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (_residueTime <= 0)
            {
                _residueTime = .3f;
                StartCoroutine(Stopwatch());
            }
            else if (_residueTime > 0)
            {
                transform.position = eventData.position;
                bool isXopen = false;
                isXopen = eventData.position.x >= Screen.width * 0.9f;

                bool isYopen = true;// = eventData.position.y >= Screen.height / 2 * 0.9f
                                    // && eventData.position.y<= Screen.height / 2 * 1.1f;

                if (isXopen && isYopen)
                {
                    Refresh();

                    if (_show != null)
                    { _show(); }
                }
            }
        }  
        private IEnumerator Stopwatch()
        {
            while (_residueTime > 0)
            {
                yield return new WaitForSeconds(.1f);

                _residueTime -= .1f;
            }
            Refresh();
        } 
        private IEnumerator CheckRotation()
        {
            Refresh(); 

            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                if (_chachedRotationOrientation != Screen.width)
                {
                    Refresh();
                }
            }
        }
        private void Refresh()
        {
            _idelPos = new Vector2(0 + _rectTransform.sizeDelta.x * 0.6f, Screen.height * 0.5f);
            _chachedRotationOrientation = Screen.width;
            _residueTime = 0;
            transform.position = _idelPos;
        }
    }
}