using EventBus;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class RotateLineService : IService
{
	[Inject] private LineGeneratorService _lineGeneratorService;
    private List<LineViewService> _lineViewServices;

    private EventBinding<OnEndRotate> _onEndRotate;
    private EventBinding<OnDecreaceX> _onDecreaceX;
    private EventBinding<OnIncreaceX> _onIncreaceX;
    private EventBinding<OnLineLocked> _onLineLocked;

    private LineViewService _currentLine;
    private int _currentId;

    public void ActivateService()
	{
        _lineViewServices = _lineGeneratorService.GetLineViewServices();
        _onEndRotate = new(EndRotate);
        _onDecreaceX = new(DecreaceX);
        _onIncreaceX = new(IncreaceX);
        _onLineLocked = new(IncreaseLine);
        _currentId = 0;
        _currentLine = _lineViewServices[_currentId];
    }

    public void IncreaseLine()
    {
        if (_currentId < _lineViewServices.Count - 1)
        {
            _currentId++;
            _currentLine = _lineViewServices[_currentId];
        }
    }

    public void IncreaceX()
    {
        _currentLine.Rotate(1);
    }

    public void DecreaceX()
    {
        _currentLine.Rotate(-1);
    }

    public void EndRotate()
    {
        _currentLine.CheckPos();
    }

}
