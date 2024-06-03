using Zenject;
using UnityEngine;
using System.Collections.Generic;
using EventBus;

public class ChoosePanelView : MonoBehaviour
{

}

public class ChoosePanelViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	[Inject] private IServiceFabric _serviceFabric;
    [Inject] private DifficultPanelViewService _difficultPanelViewService;
    [Inject] private IDifficultDataManager _difficultDataManager;
    [Inject] private IMarkerService _markerService;
	private ChoosePanelView _choosePanelView;
    private List<PicturePanelViewService> _picturePanelViewServices = new();
    private int _currentDiffucult;
    private EventBinding<OnDifficultChanged> _onDifficultChanged;

    public void ActivateService()
	{
		Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _choosePanelView = _viewFabric.Init<ChoosePanelView>(parent);
        _currentDiffucult = _difficultDataManager.GetCurrentDifficult();

        for (int i = 0; i < 3; i++)
        {
            _picturePanelViewServices.Add(_serviceFabric.InitMultiple<PicturePanelViewService>());
            _picturePanelViewServices[i].SetDifficult(i);
            _picturePanelViewServices[i].ActivateService();
            _picturePanelViewServices[i].HideView();
        }
        _picturePanelViewServices[_currentDiffucult].ShowView();
        _difficultPanelViewService.ActivateService();
        _onDifficultChanged = new(OnDifficultChanged);
    }

    private void OnDifficultChanged(OnDifficultChanged onDifficultChanged)
    {
        ChangeDifficult(onDifficultChanged.Difficult);
    }

    private void ChangeDifficult(int currentdiff)
    {
        for (int i = 0; i < 3; i++)
        {
            _picturePanelViewServices[i].HideView();
        }
        _picturePanelViewServices[currentdiff].ShowView();
    }
}
