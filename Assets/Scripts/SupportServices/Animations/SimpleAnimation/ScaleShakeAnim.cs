using DG.Tweening;
using System;
using UnityEngine;

public class ScaleShakeAnim  : Anim
{
    private float _shakeDuration;
    private float _shakeForce;
    private int _shakeVibrato;
    [SerializeField] private ShakeAnimData _currentAnimData;


    public override void OnEnable()
    {
        _animData = (AnimData)_currentAnimData;
        SetValues(_currentAnimData);
        base.OnEnable();
    }

    public override void Play(Action Oncomplete = null, float PlayDelay = 0)
    {
        _animSequence.Complete();
        _animSequence.Kill();
        _animSequence = DOTween.Sequence();
        _animSequence.AppendInterval(PlayDelay);
        _animSequence.Append(transform.DOShakeScale(_shakeDuration,
                                                       _shakeForce,
                                                       _shakeVibrato,
                                                       fadeOut: false,
                                                       randomnessMode: ShakeRandomnessMode.Harmonic));
        _animSequence.OnComplete(() => Oncomplete?.Invoke());
    }

    public override void SetValues(AnimData AnimData)
    {
        // ������ ���� �� ���������� AnimData 
        var shakeAnimData = AnimData as ShakeAnimData;
        _shakeDuration = shakeAnimData.Duration;
        _shakeForce = shakeAnimData.ShakeForce;
        _shakeVibrato = shakeAnimData.ShakeVibrato;
    }
}

