using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;

[CreateAssetMenu(fileName = "PicturesSOData", menuName = "PictureSOData")]
public class PicturesSOData : SerializedScriptableObject
{
    [DictionaryDrawerSettings(KeyLabel = "ID", ValueLabel = "Picture")]
    [SerializeField] private Dictionary<int, Sprite> _lines = new Dictionary<int, Sprite>();

    public Dictionary<int, Sprite> GetPicturesData() => _lines;

}

public interface IPicturesDataManager : IService
{
    public Sprite GetCurrentPicture();
}

public class PicturesDataManager : IPicturesDataManager
{
    [Inject] private ISOStorageService _soStorageService;
    private PicturesSOData picturesSOData;
    private int _currentPictureId;

    public void ActivateService()
    {
        // Load
        picturesSOData = _soStorageService.GetSOByType<PicturesSOData>() as PicturesSOData;
        _currentPictureId = 0;
    }

    public Sprite GetCurrentPicture() => picturesSOData.GetPicturesData().GetValueOrDefault(_currentPictureId);

}
