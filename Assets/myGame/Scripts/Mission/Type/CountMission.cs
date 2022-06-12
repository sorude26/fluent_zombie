using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Conditions/CountMission")]
public class CountMission : MissionConditions
{
    [SerializeField,Header("‘ÎÛID")]
    private int _targetID = default;
    [SerializeField,Header("–Ú•W”")]
    private int _targetCount = default;
    public override bool ClearConditions()
    {
        return GameData.Instance.CountData.ContainsKey(_targetID) && GameData.Instance.CountData[_targetID] >= _targetCount;
    }
}
