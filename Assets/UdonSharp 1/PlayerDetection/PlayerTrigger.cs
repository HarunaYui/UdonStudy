
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerTrigger : UdonSharpBehaviour
{
    public Text textField;
    void Start()
    {
        
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        textField.text = Networking.LocalPlayer.displayName;
        Debug.Log($"{Networking.LocalPlayer.displayName} Enter");
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        textField.text = Networking.LocalPlayer.displayName;
        Debug.Log($"{Networking.LocalPlayer.displayName} Exit");
    }
}
