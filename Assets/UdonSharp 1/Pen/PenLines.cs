
using BestHTTP;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PenLines : UdonSharpBehaviour
{
    private bool _isDown;
    [UdonSynced]
    private Vector3[] _points;
    public LineRenderer lineRenderer;
    void Start()
    {
        
    }

    public void OnFinish()
    {
        lineRenderer.Simplify(0.005f);
        SendCustomEvent(nameof(OnUpdate));
    }

    public void OnUpdate()
    {
        lineRenderer.GetPositions(new Vector3[lineRenderer.positionCount - 0]);
        
    }
}
