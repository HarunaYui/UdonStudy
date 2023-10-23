
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FireOnTriggerU : UdonSharpBehaviour
{
    public UdonBehaviour udonBehaviour;
    public string eventName;
    void Start()
    {
        
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        udonBehaviour.SendCustomEvent(eventName);
    }
    
}
