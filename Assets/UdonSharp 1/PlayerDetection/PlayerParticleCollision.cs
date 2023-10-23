
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerParticleCollision : UdonSharpBehaviour
{
    public GameObject target;
    void Start()
    {
        
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        target.SetActive(true);
        Debug.Log($"{player.displayName} entered");
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        target.SetActive(false);
        Debug.Log($"{player.displayName} exited");
    }
}
