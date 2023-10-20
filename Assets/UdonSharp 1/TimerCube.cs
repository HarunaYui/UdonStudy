using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TimerCube : UdonSharpBehaviour
{
    public Material[] materials;
    private int i = 0;
    private float _prevTime;
    public MeshRenderer meshRenderer;
    private readonly float _interval = 5f;
    void Start()
    {
        _prevTime = Time.time;
        Debug.Log($"prevTime = {_prevTime}");
    }

    private void Update()
    {
        if (Time.time - _prevTime >= _interval)
        {
            i = (i + 1) % materials.Length;
            meshRenderer.material = materials[i];
            _prevTime = Time.time;
            Debug.Log($"i = {i}");
        }
    }
}
