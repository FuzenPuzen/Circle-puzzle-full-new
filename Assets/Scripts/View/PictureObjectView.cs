using Zenject;
using UnityEngine;
using UnityEngine.UI;

public class PictureObjectView : MonoBehaviour
{
	[SerializeField] private Image _pictireImg;
	[SerializeField] private Image _emptyImg;
	[SerializeField] private Image _lockedImg;

}

public class PictureObjectViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private PictureObjectView _pictureObjectView;
    [Inject] private IMarkerService _markerService;

	public void ActivateService()
	{
		Transform parent = _markerService.GetMarker<PicturesPanelMarker>().transform;
        _pictureObjectView = _viewFabric.Init<PictureObjectView>(parent);
	}
}
