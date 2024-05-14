using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyLevelsSO", menuName = "DifficultyLevelsSO")]
public class DifficultyLevelsSO : SerializedScriptableObject
{
    [DictionaryDrawerSettings(KeyLabel = "ID", ValueLabel = "CirclesSOData")]
    [SerializeField] private Dictionary<int, CirclesSOData> _circlesSODatas = new Dictionary<int, CirclesSOData>();

    public CirclesSOData GetCirclesData(int id) => _circlesSODatas.GetValueOrDefault(id);
}
