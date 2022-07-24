using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 探索機能クラス
/// </summary>
/// <typeparam name="TPoint"></typeparam>
public class SearchMap<TPoint> where TPoint : IMapPoint<TPoint>
{
    /// <summary> 更新座標リスト </summary>
    private Dictionary<string, List<TPoint>> _updatePoints = new Dictionary<string, List<TPoint>>();
    /// <summary>
    /// 指定箇所から対象の足跡を付ける
    /// </summary>
    /// <param name="start"></param>
    /// <param name="targetKey"></param>
    /// <param name="power"></param>
    private void MakeFootprints(TPoint start, string targetKey, int power)
    {
        //初回確認
        if (!start.FootprintDic.ContainsKey(targetKey))
        {
            start.FootprintDic.Add(targetKey, 0);
            _updatePoints[targetKey].Add(start);
        }
        else if (start.FootprintDic[targetKey] == 0)
        {
            _updatePoints[targetKey].Add(start);
        }
        //足跡設定
        start.FootprintDic[targetKey] = power;
        foreach (var neigher in start.ConnectPoint)
        {
            if (neigher.IsNoEntry)//侵入不可
            {
                continue;
            }
            if (!neigher.FootprintDic.ContainsKey(targetKey))//初回設定
            {
                neigher.FootprintDic.Add(targetKey, 0);
            }
            if (neigher.FootprintDic[targetKey] < power - 1)//足跡設定可能であれば続行
            {
                MakeFootprints(neigher, targetKey, power - 1);
            }
        }
    }
    /// <summary>
    /// 指定箇所から対象の足跡を付ける
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
    /// 指定対象の足跡をリセットする
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
/// <summary>
/// 探索点インターフェース
/// </summary>
/// <typeparam name="TMapPoint"></typeparam>
public interface IMapPoint<TMapPoint> where TMapPoint : IMapPoint<TMapPoint>
{
    /// <summary> 生成ID </summary>
    public int IndexID { get; }
    /// <summary> 侵入不可フラグ </summary>
    public bool IsNoEntry { get; set; }
    /// <summary> 近接点リスト </summary>
    public List<TMapPoint> ConnectPoint { get; set; }
    /// <summary> 足跡ディクショナリー </summary>
    public Dictionary<string, int> FootprintDic { get; set; }
}
