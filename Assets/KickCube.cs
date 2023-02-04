using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickCube : MonoBehaviour
{

    [SerializeField]
    private LineRenderer _rootLine;
    
    [SerializeField]
    private float _growSpeed;

    public void Update()
    {
        var lastPosition = _rootLine.GetPosition(_rootLine.positionCount - 1);
        var lastIndex = _rootLine.positionCount - 1;
        _rootLine.SetPosition(lastIndex, lastPosition + _growSpeed * Vector3.down * Time.deltaTime);
        if ((_rootLine.GetPosition(lastIndex) - _rootLine.GetPosition(lastIndex - 1)).sqrMagnitude > 1)
        {
            _rootLine.positionCount ++;
            _rootLine.SetPosition(lastIndex + 1, _rootLine.GetPosition(lastIndex));
        }
    }
}
