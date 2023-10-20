
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ChairUdon : UdonSharpBehaviour
{
    private string _playerName;
    void Start()
    {
        
    }

    public override void Interact()
    {
        Networking.LocalPlayer.UseAttachedStation();
        _playerName = Networking.LocalPlayer.displayName;
    }

    public override void OnStationEntered(VRCPlayerApi player)
    {
        Debug.Log($"Player:{_playerName} has Enter");
    }

    public override void OnStationExited(VRCPlayerApi player)
    {
        Debug.Log($"Player:{_playerName} has Exited");
    }
}
