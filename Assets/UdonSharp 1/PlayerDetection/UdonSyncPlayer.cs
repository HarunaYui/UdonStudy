
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.PlayerLoop;
using VRC.SDK3.Components;
using VRC.SDK3.Video.Components.Base;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Enums;
using VRC.Udon.Editor.ProgramSources.UdonGraphProgram.UI.GraphView.UdonNodes;

public class UdonSyncPlayer : UdonSharpBehaviour
{
    public BaseVRCVideoPlayer player;
    [UdonSynced]
    private VRCUrl _url;
    public VRCUrlInputField urlInputField;
    [UdonSynced]
    private Vector2 _timeAndOffset;
    public float syncFrequency;
    public bool allowGuestControl;

    public Vector2 TimeAndOffset
    {
        get => _timeAndOffset;
        set
        {
            if (Networking.IsOwner(this.gameObject))
            {
                _timeAndOffset = value;
                SendCustomEvent(nameof(Resync));
            }
        }
    }
    
    public VRCUrl URL
    {
        get => _url;
        set
        {
            if (player.IsReady)
            {
                _url = value;
                player.PlayURL(value);
            }
        }
    }
    void Start()
    {
        
    }

    public void OnURLChanged()
    {
        if (Networking.LocalPlayer.IsValid())
        {
            Networking.SetOwner(Networking.LocalPlayer,this.gameObject);
            if (urlInputField != null)
            {
                SetProgramVariable("URL",urlInputField.GetUrl());
                RequestSerialization();
            }
        }
    }

    public override void OnVideoStart()
    {
        SendCustomEvent(nameof(UpdateTimeAndOffset));
    }

    public override bool OnOwnershipRequest(VRCPlayerApi requestingPlayer, VRCPlayerApi requestedOwner)
    {
        return allowGuestControl;
    }

    public void UpdateTimeAndOffset()
    {
        if (Networking.IsOwner(this.gameObject))
        {
            if (player.IsReady)
            {
                _timeAndOffset = new Vector2(player.GetTime(), Convert.ToSingle(Networking.GetServerTimeInSeconds()));
                RequestSerialization();
                if (syncFrequency > 0)
                {
                    SendCustomEventDelayedSeconds(nameof(UpdateTimeAndOffset),syncFrequency,EventTiming.Update);
                }
            }
            else
            {
                SendCustomEvent(nameof(Resync));
            }
        }
    }

    public void Resync()
    {
        if (player.IsReady)
        {
            var y = TimeAndOffset.y - Convert.ToSingle(Networking.GetServerTimeInSeconds());
            var result = TimeAndOffset.x + y;
            player.SetTime(result);
        }
    }
    
}
