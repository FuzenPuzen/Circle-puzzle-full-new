using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;

[ShowOdinSerializedPropertiesInInspector]
public class ScaleAnim : Anim
{
	[SerializeField] private ScaleAnimData _ScaleAnimData;

	public override void OnEnable()
	{
    	_animData = (AnimData)_ScaleAnimData;
    	SetValues(_ScaleAnimData);
    	base.OnEnable();
	}
	
 	public override void Play (Action Oncomplete = null, float PlayDelay = 0)
 	{
     	_animSequence.Kill();
     	_animSequence = DOTween.Sequence();
        _animSequence.AppendInterval(PlayDelay);
        _animSequence.Append(transform.DOScale(_ScaleAnimData.ScaleSize, _animData.Duration));
        _animSequence.OnComplete(() => Oncomplete?.Invoke());
        //Анимация
    }
	
	 public override void SetValues(AnimData AnimData)
 	{
        //_ScaleAnimData = AnimData as ScaleAnimData;
		//Парсинг данных для анимации(Если необходимо)
	}
}

[Serializable]
public class ScaleAnimData : AnimData
{
    public Vector3 ScaleSize;
}