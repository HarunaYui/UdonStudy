
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PickUpCube : UdonSharpBehaviour
{
    public Material targetMaterial;
    void Start()
    {
        targetMaterial = GetComponent<MeshRenderer>().material;
    }

    public override void OnPickupUseDown()
    {
        targetMaterial.color = Color.green;
        Debug.Log("OnPickupUseDown");
    }

    public override void OnPickupUseUp()
    {
        targetMaterial.color = Color.red;
        Debug.Log("OnPickupUseUp");
    }
}
