using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPrint : MonoBehaviour
{
    [SerializeField] private string Text;
    public void Test()
    {
        print(Text);
    }
}
