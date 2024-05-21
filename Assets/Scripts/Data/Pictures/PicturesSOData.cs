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
}

public class PicturesDataManager : IPicturesDataManager
{
    [Inject] private ISOStorageService _soStorageService;
    [Inject] private ILoadService _saveService;

    private Dictionary<int, Sprite> picturesSprites;
    private int _currentPictureId;

    private List<PictureSLData> _easyPicturesSLData = new();
    private List<PictureSLData> _mediumPicturesSLData = new();
    private List<PictureSLData> _hardPicturesSLData = new();

    private List<PictureData> _easyPicturesData = new();
    private List<PictureData> _mediumPicturesData = new();
    private List<PictureData> _hardPicturesData = new();

    private const string EasyKey = "EasyKey"; 
    private const string MediumKey = "MediumKey"; 
    private const string HardKey = "HardKey"; 

    public void ActivateService()
    {
        _easyPicturesSLData = _saveService.LoadDatas(_easyPicturesSLData, EasyKey);
        _mediumPicturesSLData = _saveService.LoadDatas(_mediumPicturesSLData, MediumKey);
        _hardPicturesSLData = _saveService.LoadDatas(_hardPicturesSLData, HardKey);

        var picturesSOData = _soStorageService.GetSOByType<PicturesSOData>() as PicturesSOData;
        picturesSprites = picturesSOData.GetPicturesData();

        if (_easyPicturesSLData.Count != picturesSprites.Count)
        {
            CreateSLData(_easyPicturesSLData, EasyKey);
            CreateSLData(_mediumPicturesSLData, MediumKey);
            CreateSLData(_hardPicturesSLData, HardKey);
        }

        ComparePictureData(_easyPicturesData, _easyPicturesSLData);
        ComparePictureData(_mediumPicturesData, _mediumPicturesSLData);
        ComparePictureData(_hardPicturesData, _hardPicturesSLData);

        _currentPictureId = 2;
    }

    public void CreateSLData(List<PictureSLData> pictureSLDatas, string key)
    {
        foreach (var picturesSprite in picturesSprites)       
            pictureSLDatas.Add(new PictureSLData());
        _saveService.SaveItem(pictureSLDatas, key);
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

    public Sprite GetCurrentPicture() => picturesSprites[_currentPictureId];

}
