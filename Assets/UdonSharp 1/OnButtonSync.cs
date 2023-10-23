using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class OnButtonSync : UdonSharpBehaviour
{
    //获取uiText文本
    public Text uiText;
    [UdonSynced,FieldChangeCallback(nameof(ClickCount))]
    private int _clickCount;
    private int ClickCount
    {
        get => _clickCount;
        set
        {
            Debug.Log("OwnerButtonAsync Update");
            uiText.text = value.ToString();
            _clickCount = value;
        }
    }

    void Start()
    {
        
    }

    public void UpdateClickCount()
    {
        //如果是主机的话就+1
        if (Networking.IsOwner(this.gameObject))
        {
            ClickCount++;
        }
    }
}
