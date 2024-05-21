using Zenject;
using UnityEngine;

public class PicturePanelView : MonoBehaviour
{

}

public class PicturePanelViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private PicturePanelView _PicturePanelView;
    [Inject] private IMarkerService _markerService;

	public void ActivateService()
	{
        Transform parent = _markerService.GetMarker<ChoosePanelMarker>().transform;
        _PicturePanelView = _viewFabric.Init<PicturePanelView>(parent);
	}
}
