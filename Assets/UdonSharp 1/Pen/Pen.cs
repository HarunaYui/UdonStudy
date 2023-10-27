
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Pen : UdonSharpBehaviour
{
    private UdonBehaviour _line;
    private bool _isDrawing;
    private Vector3 _startPosition = new Vector3(0, 0, 0);
    public float minMoveDistance = 0.1f;
    private Vector3 _points;
    private LineRenderer _lineRenderer;
    public Transform penTip;
    private int _currentIndex = -1;
    public int pointsPerUpdate = 10;
    public Transform linesContainer;
    [UdonSynced] private int _nextLineIndex = 0;
    private GameObject[] _pool;
    private LineRenderer[] _linePool;

    void Start()
    {
        _linePool = linesContainer.transform.GetComponentInChildren<LineRenderer[]>();
    }

    public override bool OnOwnershipRequest(VRCPlayerApi requestingPlayer, VRCPlayerApi requestedOwner)
    {
        return true;
    }

    public override void OnPickupUseDown()
    {
        _lineRenderer = _linePool[_nextLineIndex];
        _line = _linePool[_nextLineIndex].GetComponent<UdonBehaviour>();
        Networking.SetOwner(Networking.LocalPlayer,_linePool[_nextLineIndex].gameObject);
        _linePool[_nextLineIndex].gameObject.SetActive(true);
        
        if (_nextLineIndex + 1 >= _linePool.Length)
        {
            _nextLineIndex = 0;
        }
        else
        {
            _nextLineIndex += 1;
        }

        _isDrawing = true;
        _lineRenderer.positionCount = 2;
        _startPosition = penTip.transform.position;
        _currentIndex = 0;

        for (int i = 0; i < 2; i++)
        {
            _lineRenderer.SetPosition(i,penTip.transform.position);
        }
    }

    private void Update()
    {
        if (_isDrawing)
        {
            if (Vector3.Distance(penTip.transform.position, _startPosition) > minMoveDistance)
            {
                _lineRenderer.positionCount = _currentIndex + 1;
            }
            _lineRenderer.SetPosition(_currentIndex,penTip.position);
            _startPosition = penTip.position;
            _currentIndex += 1;
            if (_currentIndex % pointsPerUpdate == 0)
            {
                _line.SendCustomEvent(nameof(PenLines.OnUpdate));
            }
        }
    }

    public override void OnPickupUseUp()
    {
        _isDrawing = false;
        _line.SendCustomEvent(nameof(OnFinish));
    }
}
