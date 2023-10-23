
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class LabelForSlider : UdonSharpBehaviour
{
    public Slider uiSlider;
    private float _sliderValue;
    public Text uiText;

    public float SilderValue
    {
        set
        {
            _sliderValue = value;
            uiText.text = value.ToString();
            uiSlider.value = value;
        }
    }
    void Start()
    {
        
    }

    public void OnValueChanged()
    {
        if (!Networking.IsOwner(this.gameObject))
        {
            Networking.SetOwner(Networking.LocalPlayer,this.gameObject);
            SilderValue = uiSlider.value;
            RequestSerialization();
        }
    }
    
}
