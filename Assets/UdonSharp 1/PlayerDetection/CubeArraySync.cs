
using System;
using UdonSharp;
using UnityEngine;
using VRC.Core;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common;
using VRC.Udon.Common.Interfaces;
using Random = UnityEngine.Random;

public class CubeArraySync : UdonSharpBehaviour
{
    public GameObject[] cubes;
    [UdonSynced]
    private bool[] _data = new bool[25];
    void Start()
    {
        
    }

    public override void Interact()
    {
        Debug.Log($"CubeArraySyncUSharp => Interact()");
        SendCustomNetworkEvent(NetworkEventTarget.Owner,nameof(Randomize));
    }

    public void Randomize()
    {
        Debug.Log($"CubeArraySyncUSharp => Interact()");
        for (int i = 0; i < _data.Length; i++)
        {
            _data[i] = Random.value > 0.5f;
        }
        //向主机发送
        RequestSerialization();
        SendCustomEvent(nameof(UpdateCubes));
    }

    public override void OnDeserialization()
    {
        Debug.Log($"CubeArraySyncUSharp => OnDeserialization()");
        SendCustomEvent(nameof(UpdateCubes));
    }

    public void UpdateCubes()
    {
        Debug.Log($"CubeArraySyncUSharp => UpdateCubes()");
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].SetActive(_data[i]);
        }   
    }
}
