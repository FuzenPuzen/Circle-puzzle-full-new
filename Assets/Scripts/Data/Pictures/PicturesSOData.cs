using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;
using ModestTree;

[CreateAssetMenu(fileName = "PicturesSOData", menuName = "PictureSOData")]
public class PicturesSOData : SerializedScriptableObject
{
    [DictionaryDrawerSettings(KeyLabel = "ID", ValueLabel = "Picture")]
    [SerializeField] private Dictionary<int, Sprite> _lines = new Dictionary<int, Sprite>();

    public Dictionary<int, Sprite> GetPicturesData() => _lines;

}

public class PictureSLData
{
    public int Id;
    public bool IsOpen = false;
    public bool IsFinish = false;
}

public class PictureData
{
    public Sprite Sprite;
    public PictureSLData PictureSLData;
}

public interface IPicturesDataManager : IService
{
    public Sprite GetCurrentPicture();
    public List<PictureData> GetDifficultPictureData(int diffId);
}

public class PicturesDataManager : IPicturesDataManager
{
    [Inject] private ISOStorageService _soStorageService;
    [Inject] private ILoadService _saveService;

    private Dictionary<int, Sprite> picturesSprites;
    private int _currentPictureId;

    private List<List<PictureSLData>> _PicturesSLDatas = new();

    private List<List<PictureData>> _picturesData = new();

    private const string PictureDataKey = "PictureDataKey"; 

    public void ActivateService()
    {
        _PicturesSLDatas = _saveService.LoadDatas(_PicturesSLDatas, PictureDataKey);

        var picturesSOData = _soStorageService.GetSOByType<PicturesSOData>() as PicturesSOData;
        picturesSprites = picturesSOData.GetPicturesData();

        if (_PicturesSLDatas.IsEmpty())
        {
            for (int i = 0; i < 3; i++)
            {
                _PicturesSLDatas.Add(new List<PictureSLData>());
                CreateSLData(_PicturesSLDatas[i], PictureDataKey);
            }
            _saveService.SaveItem(_PicturesSLDatas, PictureDataKey);
        }

        for (int i = 0; i < _PicturesSLDatas.Count; i++)
        {
            _picturesData.Add(new List<PictureData>());
            ComparePictureData(_picturesData[i], _PicturesSLDatas[i]);
        }

        _currentPictureId = 2;
    }

    public void CreateSLData(List<PictureSLData> pictureSLDatas, string key)
    {
        MonoBehaviour.print("CreateSLData");
        foreach (var picturesSprite in picturesSprites)       
            pictureSLDatas.Add(new PictureSLData());       
    }

    public void ComparePictureData(List<PictureData> pictureDatas, List<PictureSLData> pictureSLDatas)
    {
        for (int i = 0; i < pictureSLDatas.Count; i++)
        {
            pictureDatas.Add(new PictureData());
            pictureDatas[i].Sprite = picturesSprites[i];
            pictureDatas[i].PictureSLData = pictureSLDatas[i];
        }
    }

    public List<PictureData> GetDifficultPictureData(int diffId) => _picturesData[diffId];

    public Sprite GetCurrentPicture() => picturesSprites[_currentPictureId];

}
