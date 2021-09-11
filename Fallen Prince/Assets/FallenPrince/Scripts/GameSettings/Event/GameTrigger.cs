using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallenPrice.Event
{
    public class GameTrigger : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            Destroy(spriteRenderer);
        }
    }
}

