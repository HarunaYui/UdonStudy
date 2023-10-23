
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class OnButtonSyncAnyone : UdonSharpBehaviour
{
    public Text uiText;
    [UdonSynced,FieldChangeCallback(nameof(ClickCount))]
    private int _clickCount;

    public int ClickCount
    {
        get => _clickCount;
        set
        {
            Debug.Log("OnButtonSync Anyone Update");
            uiText.text = value.ToString();
            _clickCount = value;
        }
    }
    void Start()
    {
        
    }

    public void UpdateClickCount()
    {
        ClickCount++;
    }
}
