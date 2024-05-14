using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using UnityEngine.UI;

[ShowOdinSerializedPropertiesInInspector]
public class FadeAnim : Anim
{
	[SerializeField] private FadeAnimData _FadeAnimData;
	public override void OnEnable()
	{
    		_animData = (AnimData)_FadeAnimData;
    		SetValues(_FadeAnimData);
    		base.OnEnable();
	}
	
 	public override void Play(Action Oncomplete = null, float PlayDelay = 0)
    {
     	_animSequence.Kill();
     	_animSequence = DOTween.Sequence();
        _animSequence.AppendInterval(PlayDelay);
        _animSequence.Append(transform.GetComponent<Image>().DOFade(0, _animData.Duration));
        _animSequence.OnComplete(() => Oncomplete?.Invoke());      
    }
	
	 public override void SetValues(AnimData AnimData)
 	{
		//var FadeAnimData = AnimData as FadeAnimData;
		//Парсинг данных для анимации(Если необходимо)
	}
}

[Serializable]
public class FadeAnimData : AnimData
{
   //Класс данных для анимации
}