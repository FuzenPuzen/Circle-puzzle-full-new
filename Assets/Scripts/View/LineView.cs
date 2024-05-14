using Zenject;
using UnityEngine;
using UnityEngine.UI;
using System;
using EventBus;

public class LineView : MonoBehaviour
{
    private Image _maskImage;
    private Image _pictireImage;
    private float _startRotation;
    public Action Locking;
    private bool _locked = false;
    private float _lockGap = 10f;

    private void Awake()
    {
        _maskImage = GetComponent<Image>();
        _pictireImage = transform.GetChild(0).GetComponent<Image>();
        UnFocus();
    }

    public void SetLineData(LineData lineData)
    {
        _maskImage.sprite = lineData.MaskImage;
        //_pictireImage.sprite = lineData.PictireImage;
        _startRotation = lineData.StartRotation;
        _maskImage.SetNativeSize();
        transform.rotation = Quaternion.Euler(0, 0, _startRotation);
    }

    public void Rotate(int side)
    {
        if(_locked) return;
        transform.Rotate(new Vector3(0, 0, side));
    }

    public void CheckPos()
    {
        float rotationZ = Mathf.Repeat(transform.eulerAngles.z, 360f);
        Debug.Log(rotationZ);
        if (Mathf.Abs(rotationZ) <= _lockGap || Mathf.Abs(rotationZ - 360f) <= _lockGap)
        {
            _locked = true;
            EventBus<OnLineLocked>.Raise();
            Locking.Invoke();
            transform.rotation = Quaternion.identity;
        }
    }

    public void Focus()
    {
        
    }

    public void UnFocus()
    {
        
    }

}

public class LineViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
    [Inject] private IMarkerService _markerService;
    private LineView _lineView;
    private bool _isLocked;

	public void ActivateService()
	{
        Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _lineView = _viewFabric.Init<LineView>(parent);
        _lineView.Locking = Locking;
    }

    public void CheckPos()
    {
        _lineView.CheckPos();
    }

    public void SetLineData(LineData lineData)
    {
        _lineView.SetLineData(lineData);
    }

    public void Locking()
    {
        _isLocked = true;
        _lineView.Focus();
    }

    public void Rotate(int side)
    {
        _lineView.Rotate(side);
    }

    public void Focus()
    {
        if(!_isLocked)
            _lineView.Focus();
    }

    public void UnFocus()
    {
        if (!_isLocked)
            _lineView.UnFocus();
    }

}

public struct LineData
{
    public Sprite MaskImage;
    public Sprite PictireImage;
    public float StartRotation;
}
