using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenPrice
{
    public class CheakCircleOverlap : MonoBehaviour
    {
        [SerializeField] Collider2D[] _intaractResult = new Collider2D[5];
        [SerializeField] private float _radius = 1;
        [SerializeField] private LayerMask Layer;
        public GameObject[] Cheak()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _intaractResult, Layer);
            var OverLap = new List<GameObject>();
            for (var i = 0; i < size; i++)
            {
              
                OverLap.Add(_intaractResult[i].gameObject);
            }
            return OverLap.ToArray();
        }
    }
}


   