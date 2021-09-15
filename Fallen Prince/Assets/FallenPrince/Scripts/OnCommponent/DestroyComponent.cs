using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenPrice.Component
{
    public class DestroyComponent : MonoBehaviour
    {
        public float _timeDestroy;

        public void DestroyObject()
        {
            _timeDestroy -= Time.deltaTime;
            if(_timeDestroy <= 0)
            Destroy(gameObject);
        }
    }
}

