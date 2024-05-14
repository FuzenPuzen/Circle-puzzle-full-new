using Zenject;
using UnityEngine;

public class ChoosePanelView : MonoBehaviour
{

}

public class ChoosePanelViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private ChoosePanelView _ChoosePanelView;
    [Inject] private IMarkerService _markerService;

	public void ActivateService()
	{
		Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _ChoosePanelView = _viewFabric.Init<ChoosePanelView>(parent);
	}
}
