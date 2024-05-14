using Zenject;
using UnityEngine;

public class MainCameraView : MonoBehaviour
{

}

public class MainCameraViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private MainCameraView _MainCameraView;
    [Inject] private IMarkerService _markerService;

	public void ActivateService()
	{       
        _MainCameraView = _viewFabric.Init<MainCameraView>();
	}

	public Camera GetCamera() => _MainCameraView.GetComponent<Camera>();
}
