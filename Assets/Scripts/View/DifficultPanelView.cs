using Zenject;
using UnityEngine;

public class DifficultPanelView : MonoBehaviour
{

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
