using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenPrice.Model;
using UnityEngine.UI;
using UnityEngine.Events;

namespace FallenPrice.Component
{
    public class CaptureAreaComponent : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _timeCapture;
        [SerializeField] private float _CaptureArea;
        [SerializeField] private UnityEvent _action;
        [Header("UI")]
        [SerializeField] private GameObject _progressValue;
        private Slider _progress;
        [SerializeField] private Vector3 _offset;


        private UnitData _unitData;
        private void Awake()
        {
            _progressValue.SetActive(true);
            _progress = _progressValue.GetComponentInChildren<Slider>();
            HistoreTime = _timeCapture;
            _progress.maxValue = _timeCapture;
            _unitData = FindObjectOfType<UnitData>();
            
        }

        private float HistoreTime;
        private void Update()
        {
            _progress.value = _timeCapture;
            if (Vector2.Distance(this.transform.position,_unitData.Player.transform.position) <= _CaptureArea)
            {
                if(_progress != null)
                {
                    _progressValue.SetActive(true);
                    _progress.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + _offset);
                }
                _timeCapture -= Time.deltaTime;
            }
            else
            {
                if (_timeCapture >= HistoreTime)
                {
                    _progressValue.SetActive(false);
                }
                    if (HistoreTime != _timeCapture && _timeCapture > 0)
                {
                    _timeCapture += Time.deltaTime;
                }
                if(_timeCapture > HistoreTime)
                {
                    _timeCapture = HistoreTime;
                }
                if(_progressValue != null)
                _progress.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + _offset);
            }
            if(_timeCapture <= 0)
            {
                _action?.Invoke();
                Destroy(_progressValue);
                _timeCapture = 0;
            }
        }
    }
}

