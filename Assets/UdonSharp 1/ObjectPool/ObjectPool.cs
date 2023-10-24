
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class ObjectPool : UdonSharpBehaviour
{
    private float _lastSpawnTime;
    public VRCObjectPool pool;
    public float spawnRate;
    void Start()
    {
        //开始时设置float的最小值
        _lastSpawnTime = float.MinValue;
    }

    private void Update()
    {
        //如果时间间隔大于0.5秒,和是否是自己则生成pool并设置lastSpawnTime为场景生成时间
        if (Time.realtimeSinceStartup - _lastSpawnTime > spawnRate && Networking.IsOwner(this.gameObject))
        {
            _lastSpawnTime = Time.realtimeSinceStartup;
            pool.TryToSpawn();
        }
    }
}
