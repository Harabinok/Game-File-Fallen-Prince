using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenPrice.Component
{
    public class DestroyComponent : MonoBehaviour
    {
        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}

