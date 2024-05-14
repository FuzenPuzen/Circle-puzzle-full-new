using Zenject;
using UnityEngine;

public class GameCanvasView : MonoBehaviour
{
	private Canvas _canvas;

    public void SetCamera(Camera camera)
    {
        _canvas = GetComponent<Canvas>();
        _canvas.worldCamera = camera;
    }

    public Canvas GetCanvas() => _canvas;
}

public class GameCanvasViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private GameCanvasView _GameCanvasView;
    [Inject] private IMarkerService _markerService;
    [Inject] private MainCameraViewService _mainCameraViewService;
	

	public void ActivateService()
	{       
        _GameCanvasView = _viewFabric.Init<GameCanvasView>();
        _GameCanvasView.SetCamera(_mainCameraViewService.GetCamera());
    }

    public Canvas GetCanvas() => _GameCanvasView.GetCanvas();
}
