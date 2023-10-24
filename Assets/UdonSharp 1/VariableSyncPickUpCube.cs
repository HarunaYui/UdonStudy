
using System;
using UdonSharp;
using UnityEngine;
using VRC.Collections;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;

public class VariableSyncPickUpCube : UdonSharpBehaviour
{
    public Color fromColor;
    public Renderer targetRenderer;
    public Color toColor;
    [UdonSynced]
    private Color _syncColor;
    public VRCPickup pickup;
    void Start()
    {
        
    }

    private void Update()
    {
        //如果拾取物体并持续拾取状态则
        if (Networking.IsOwner(pickup.gameObject) && pickup.IsHeld)
        {
            //颜色渐变设置
            _syncColor = Color.LerpUnclamped(fromColor, toColor, Mathf.Sin(Time.time));
            targetRenderer.material.SetColor( "_Color",_syncColor);
            
        }
    }

    public override void OnOwnershipTransferred(VRCPlayerApi player)
    {
        Debug.Log($"{player.displayName}");
    }
}
