using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �T���@�\�N���X
/// </summary>
/// <typeparam name="TPoint"></typeparam>
public class SearchMap<TPoint> where TPoint : IMapPoint<TPoint>
{
    /// <summary> �X�V���W���X�g </summary>
    private Dictionary<string, List<TPoint>> _updatePoints = new Dictionary<string, List<TPoint>>();
    /// <summary>
    /// �w��ӏ�����Ώۂ̑��Ղ�t����
    /// </summary>
    /// <param name="start"></param>
    /// <param name="targetKey"></param>
    /// <param name="power"></param>
    private void MakeFootprints(TPoint start, string targetKey, int power)
    {
        //����m�F
        if (!start.FootprintDic.ContainsKey(targetKey))
        {
            start.FootprintDic.Add(targetKey, 0);
            _updatePoints[targetKey].Add(start);
        }
        else if (start.FootprintDic[targetKey] == 0)
        {
            _updatePoints[targetKey].Add(start);
        }
        //���Րݒ�
        start.FootprintDic[targetKey] = power;
        foreach (var neigher in start.ConnectPoint)
        {
            if (neigher.IsNoEntry)//�N���s��
            {
                continue;
            }
            if (!neigher.FootprintDic.ContainsKey(targetKey))//����ݒ�
            {
                neigher.FootprintDic.Add(targetKey, 0);
            }
            if (neigher.FootprintDic[targetKey] < power - 1)//���Րݒ�\�ł���Α��s
            {
                MakeFootprints(neigher, targetKey, power - 1);
            }
        }
    }
    /// <summary>
    /// �w��ӏ�����Ώۂ̑��Ղ�t����
    /// </summary>
    /// <param name="start"></param>
    /// <param name="targetKey"></param>
    /// <param name="power"></param>
    public void StartMakeFootprints(TPoint start, string targetKey, int power)
    {
        if (!_updatePoints.ContainsKey(targetKey))
        {
            _updatePoints.Add(targetKey, new List<TPoint>());
        }
        MakeFootprints(start, targetKey, power);
    }
    /// <summary>
    /// �w��Ώۂ̑��Ղ����Z�b�g����
    /// </summary>
    /// <param name="targetKey"></param>
    public void ResetFootprints(string targetKey)
    {
        if (!_updatePoints.ContainsKey(targetKey)) { return; }
        foreach (var point in _updatePoints[targetKey])
        {
            if (!point.FootprintDic.ContainsKey(targetKey))
            {
                continue;
            }
            point.FootprintDic[targetKey] = 0;
        }
        _updatePoints[targetKey].Clear();
    }
}

public interface IMapPoint<TMapPoint> where TMapPoint : IMapPoint<TMapPoint>
{
    public int IndexID { get; }
    public bool IsNoEntry { get; set; }
    public List<TMapPoint> ConnectPoint { get; set; }
    public Dictionary<string, int> FootprintDic { get; set; }
}
