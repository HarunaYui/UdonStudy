using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ClickableCube : UdonSharpBehaviour
{
    public Material[] materials;
    private int i = 0;
    public MeshRenderer meshRenderer;
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        i = (i + 1) % materials.Length;
        meshRenderer.material = materials[i];
        Debug.Log($"i = {i}");
    }
}
