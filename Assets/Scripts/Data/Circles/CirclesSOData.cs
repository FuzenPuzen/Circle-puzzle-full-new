using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "CirclesSOData", menuName = "CirclesSOData")]
public class CirclesSOData : SerializedScriptableObject
{
    [DictionaryDrawerSettings(KeyLabel = "ID", ValueLabel = "Sprite")]
    [SerializeField] private Dictionary<int, Sprite> _lines = new Dictionary<int, Sprite>();

    public Dictionary<int, Sprite> GetLinesData() => _lines;

}
