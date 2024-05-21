using Zenject;
using UnityEngine;
using System.Collections.Generic;

public class ChoosePanelView : MonoBehaviour
{

}

public class ChoosePanelViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	[Inject] private IServiceFabric _serviceFabric;
	private ChoosePanelView _choosePanelView;
    [Inject] private IMarkerService _markerService;
    private List<PicturePanelViewService> _picturePanelViewServices = new();
    [Inject] private DifficultPanelViewService _difficultPanelViewService;

    public void ActivateService()
	{
		Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _choosePanelView = _viewFabric.Init<ChoosePanelView>(parent);

        for (int i = 0; i < 3; i++)
        {
            _picturePanelViewServices.Add(_serviceFabric.InitMultiple<PicturePanelViewService>());
            _picturePanelViewServices[i].ActivateService();
        }

        _difficultPanelViewService.ActivateService();
    }
}
