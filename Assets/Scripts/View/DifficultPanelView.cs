using Zenject;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using EventBus;

public class DifficultPanelView : MonoBehaviour
{
	[SerializeField] private List<Button> _diffButtons = new();

    private void Awake()
    {
        _diffButtons[0].onClick.AddListener(SetEasyDiff);
        _diffButtons[1].onClick.AddListener(SetMediumDiff);
        _diffButtons[2].onClick.AddListener(SetHardDiff);
    }

    private void SetEasyDiff()
    {
        EventBus<OnDifficultChanged>.Raise(new() { Difficult = 0 });
    }

    private void SetMediumDiff()
    {
        EventBus<OnDifficultChanged>.Raise(new() { Difficult = 1 });
    }

    private void SetHardDiff()
    {
        EventBus<OnDifficultChanged>.Raise(new() { Difficult = 2 });
    }
}

public class DifficultPanelViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private DifficultPanelView _DifficultPanelView;
    [Inject] private IMarkerService _markerService;

	public void ActivateService()
	{
        Transform parent = _markerService.GetMarker<ChoosePanelMarker>().transform;
        _DifficultPanelView = _viewFabric.Init<DifficultPanelView>(parent);
	}
}
