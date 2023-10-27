
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DoorControllerTrigger : UdonSharpBehaviour
{
    public UdonBehaviour doorOpenUdonBehaviour;
    public string doorUdonBehaviorOpenEventName;
    public string doorUdonBehaviorCloseEventName;

    public override void OnPlayerCollisionEnter(VRCPlayerApi player)
    {
        Debug.Log($"Door : Enter");
        doorOpenUdonBehaviour.SendCustomEvent("doorUdonBehaviorOpenEventName");
    }

    public override void OnPlayerCollisionExit(VRCPlayerApi player)
    {
        Debug.Log($"Door : Exit");
        doorOpenUdonBehaviour.SendCustomEvent("doorUdonBehaviorCloseEventName");
    }
}
