using EventBus;
using System;
using UnityEngine;
using Zenject;

public interface IAudioDataManager
{
    public AudioClip GetAudioSOData(AudioEnum audioName);
    public AudioSLData GetAudioSLData();
    public void SetAudioSLData(AudioSLData audioSLData);
    public void SetMute();
    public void SetMax();
}


public class AudioDataManager : IAudioDataManager
{
    private const string AudioKey = "AudioKey";
    [Inject] private ISOStorageService _storageService;
    [Inject] private ILoadService _loadService;
    private AudioSOData _audioSOData;
    private AudioSLData _audioSLData;
    private EventBinding<OnMute> _onMute;
    private EventBinding<OnUnMute> _onUnMute;

    public void ActivateService()
    {
        _audioSOData = (AudioSOData)_storageService.GetSOByType<AudioSOData>();
        LoadAudioData();
        _onMute = new(SetMute);
        _onUnMute = new(SetMax);
    }

    public void SetMute()
    {
        _audioSLData.MusicValue = 0;
        _audioSLData.SoundValue = 0;
        _loadService.SaveItem<AudioSLData>(_audioSLData, AudioKey);
    }

    public void SetMax()
    {
        _audioSLData.MusicValue = 0.8f;
        _audioSLData.SoundValue = 0.8f;
        _loadService.SaveItem<AudioSLData>(_audioSLData, AudioKey);
    }

    public AudioClip GetAudioSOData(AudioEnum audioName) => _audioSOData.audioDictionary[audioName];
    public AudioSLData GetAudioSLData() => _audioSLData;
    public void SetAudioSLData(AudioSLData audioSLData)
    {
        _audioSLData = audioSLData;
        _audioSLData.MusicValue = Math.Clamp(_audioSLData.MusicValue, 0, 0.8f);
        _audioSLData.SoundValue = Math.Clamp(_audioSLData.SoundValue, 0, 0.8f);
        _loadService.SaveItem<AudioSLData>(_audioSLData, AudioKey);
    }

    public void LoadAudioData()
    {
        _audioSLData = new();
        _audioSLData = _loadService.LoadData(_audioSLData, AudioKey);      
    }
}

public class AudioSLData
{
    public float MusicValue = 1;
    public float SoundValue = 1;
}
