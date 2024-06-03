using Zenject;
using UnityEngine;
using System.Collections.Generic;

public class PicturePanelView : MonoBehaviour
{
	public Transform GetContentTransform()
	{
		return transform.GetChild(0);
	}

    public void HideView()
    {
		gameObject.SetActive(false);
    }

    public void ShowView()
    {
		gameObject.SetActive(true);
    }
}

public class PicturePanelViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	[Inject] private IServiceFabric _serviceFabric;
    [Inject] private IMarkerService _markerService;
    [Inject] private IPicturesDataManager _picturesDataManager;

	private PicturePanelView _PicturePanelView;
	private List<PictureObjectViewService> _pictureObjectViewServices = new();
	private List<PictureData> _pictureDatas;
	private int diffId;

	public void ActivateService()
	{
        Transform parent = _markerService.GetMarker<ChoosePanelMarker>().transform;
        _PicturePanelView = _viewFabric.Init<PicturePanelView>(parent);
		_pictureDatas = _picturesDataManager.GetDifficultPictureData(diffId);

		foreach (var pictureData in _pictureDatas)
		{
			var pictureObject = _serviceFabric.InitMultiple<PictureObjectViewService>();
            pictureObject.SetPictureData(pictureData, _PicturePanelView.GetContentTransform());
            pictureObject.ActivateService();
            _pictureObjectViewServices.Add(pictureObject);
        }

    }

	public void SetDifficult(int id)
	{
		diffId = id;
	}

	public void HideView() => _PicturePanelView.HideView();

	public void ShowView() => _PicturePanelView.ShowView();

}
