
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class LoopCube : UdonSharpBehaviour
{
    public Text _text;
    private string textConcat;
    void Start()
    {
        _text = GetComponentInChildren<Text>();
    }

    private void OnMouseDown()
    {
        textConcat = null;
        for (int i = 0; i < 9; i++)
        {
            textConcat += string.Concat(i);
        }
        _text.text = textConcat;
    }
}
