
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class ButtonSyncBecomeOwner : UdonSharpBehaviour
{
    public Text uiText;
    [UdonSynced,FieldChangeCallback(nameof(ClickCount))]
    private int _clickCount;

    public int ClickCount
    {
        get => _clickCount;
        set
        {
            Debug.Log("set owner and update click");
            uiText.text = value.ToString();
            _clickCount = value;
        }
    }
    void Start()
    {
        
    }

    public void UpdateClickCount()
    {
        if (Networking.IsOwner(this.gameObject))
        {
            ClickCount++;
        }
        else
        {
            Networking.SetOwner(Networking.LocalPlayer,this.gameObject);
            ClickCount++;
        }
    }
}
