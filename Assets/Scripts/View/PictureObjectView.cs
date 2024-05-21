using Zenject;
using UnityEngine;
using UnityEngine.UI;

public class PictureObjectView : MonoBehaviour
{
	[SerializeField] private Image _pictireImg;
	[SerializeField] private Image _emptyImg;
	[SerializeField] private Image _lockedImg;

    public void SetPictureData(PictureData pictureData)
    {
        _pictireImg.sprite = pictureData.Sprite;
        if (pictureData.PictureSLData.IsOpen)
        {
            _emptyImg.gameObject.SetActive(false);
            _lockedImg.gameObject.SetActive(false);
        }
    }

}

public class PictureObjectViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private PictureObjectView _pictureObjectView;
    [Inject] private IMarkerService _markerService;
	private PictureData _pictureData;
	private Transform _parent;

	public void ActivateService()
	{
        _pictureObjectView = _viewFabric.Init<PictureObjectView>(_parent);
        _pictureObjectView.SetPictureData(_pictureData);

    }

	public void SetPictureData(PictureData pictureData, Transform parent)
	{
        _pictureData = pictureData;
        _parent = parent;
    }
}
