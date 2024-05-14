using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;

[ShowOdinSerializedPropertiesInInspector]
public class RotateAnim : Anim
{
	[SerializeField] private RotateAnimData _RotateAnimData;
	public override void OnEnable()
	{
    		_animData = (AnimData)_RotateAnimData;
    		SetValues(_RotateAnimData);
    		base.OnEnable();
	}
	
 	public override void Play(Action Oncomplete = null, float PlayDelay = 0)
    {
     	_animSequence.Kill();
     	_animSequence = DOTween.Sequence();
        _animSequence.AppendInterval(PlayDelay);
        _animSequence.Append(transform.DOLocalRotate(_RotateAnimData.RotationVector,
                                                        _RotateAnimData.Duration, _RotateAnimData.RotateMod)
                                                        .SetEase(Ease.Linear));
        _animSequence.OnComplete(() => Oncomplete?.Invoke());
        if (_RotateAnimData.IsReverse)
            _RotateAnimData.RotationVector = -_RotateAnimData.RotationVector;

    }
	
	public override void SetValues(AnimData AnimData)
 	{
		//Парсинг данных для анимации(Если необходимо)
	}
}

[Serializable]
public class RotateAnimData : AnimData
{
	[SerializeField] public Vector3 RotationVector;
	[SerializeField] public bool IsReverse;
	[SerializeField] public RotateMode RotateMod = RotateMode.LocalAxisAdd;
   //Класс данных для анимации
}