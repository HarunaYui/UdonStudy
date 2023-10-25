
using System;
using UdonSharp;
using UnityEngine;
using VRC.Core;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

public class PooledBox : UdonSharpBehaviour
{
    public VRCObjectPool pool;
    private VRCObjectSync _objectSync;

    void Start()
    {
        if (this.GetComponent<VRCObjectSync>() != null)
        {
            _objectSync = this.GetComponent<VRCObjectSync>();
        }
    }

    private void OnEnable()
    {
        if (_objectSync != null)
            _objectSync.Respawn();
    }

    public void ReturnObject()
    {
        pool.Return(this.gameObject);
    }

    public override void Interact()
    {
        if (Networking.IsOwner(this.gameObject))
        {
            pool.Return(this.gameObject);
        }
        else
        {
            SendCustomNetworkEvent(NetworkEventTarget.Owner,nameof(ReturnObject));
        }
    }
}
