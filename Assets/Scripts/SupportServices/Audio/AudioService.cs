using EventBus;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IAudioService : IService
{
	public AudioUnitViewService PlayAudio(AudioEnum name, bool isLoop);
	public void StopAudio(AudioUnitViewService audio);
}

public class AudioService : IAudioService
{
    [Inject] private IPoolsViewService _poolsViewService;
    private IPoolViewService _audioUnitPoolViewService;
    [Inject] private IAudioDataManager _audioDataManager;


    private List<AudioUnitViewService> _activeAudioUnit = new();

	public void ActivateService()
	{
		_audioUnitPoolViewService = _poolsViewService.GetPool<AudioUnitViewService>();

    }

	public AudioUnitViewService PlayAudio(AudioEnum name, bool isLoop = false)
	{
		AudioUnitViewService audio = (AudioUnitViewService)_audioUnitPoolViewService.GetItem<AudioUnitViewService>();
		audio.Play(new StartValues() {Clip = _audioDataManager.GetAudioSOData(name), IsLoopClip = isLoop });
		_activeAudioUnit.Add(audio);
		return audio;
    }

    public void StopAudio(AudioUnitViewService audio)
    {
        _activeAudioUnit.Remove(audio);
		audio.DeactivateServiceToPool();
    }
}
