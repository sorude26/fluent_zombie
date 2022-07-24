using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
/// <summary>
/// 誘導マップ
/// </summary>
public class NavigationMap
{
    private int _power = default;
    private NaviPoint _currentTarget = default;
    private Thread _therad = default;
    private List<NaviPoint> _naviMap = default;
    private SearchMap<NaviPoint> _searchMap = new SearchMap<NaviPoint>();
    /// <summary> 誘導点リスト </summary>
    public List<NaviPoint> NaviMap { get { return _naviMap; } }
    public NavigationMap(List<NaviPoint> naviMap)
    {
        _naviMap = naviMap;
    }
    /// <summary>
    /// 探索処理
    /// </summary>
    /// <param name="targetKey"></param>
    private void MakeFootprints(string targetKey)
    {
        _searchMap.ResetFootprints(targetKey);
        _searchMap.StartMakeFootprints(_currentTarget, targetKey, _power);
    }
    /// <summary>
    /// 指定対象の探索処理を別スレッドで行う
    /// </summary>
    /// <param name="target"></param>
    /// <param name="targetKey"></param>
    /// <param name="power"></param>
    public void MakeFootprints(Transform target, string targetKey, int power)
    {
        var tPoint = _naviMap.OrderBy(point => Vector3.Distance(point.Pos, target.position)).FirstOrDefault();
        if (tPoint == null) { return; }
        _currentTarget = tPoint;
        _power = power;
        _therad = new Thread(new ThreadStart(() => MakeFootprints(targetKey)));
        _therad.Start();
    }
    /// <summary>
    /// ユーザーの移動方向を返す
    /// </summary>
    /// <param name="user"></param>
    /// <param name="targetKey"></param>
    /// <returns></returns>
    public Vector3 GetMoveDir(Transform user, string targetKey)
    {
        var uPoint = _naviMap.Where(point => !point.IsNoEntry).OrderBy(point => Vector3.Distance(point.Pos, user.position)).FirstOrDefault();
        if (uPoint == null || !uPoint.FootprintDic.ContainsKey(targetKey)) { return Vector3.zero; }
        var target = uPoint.ConnectPoint
            .Where(point => point.FootprintDic.ContainsKey(targetKey) && uPoint.FootprintDic[targetKey] + 1 == point.FootprintDic[targetKey])
            .OrderBy(point => Vector3.Distance(point.Pos, user.position))
            .FirstOrDefault();
        if (target == null) { return Vector3.zero; }
        var dir = target.Pos - user.transform.position;
        dir.y = 0;
        return dir.normalized;
    }
    /// <summary>
    /// ユーザーの現地点の足跡を返す
    /// </summary>
    /// <param name="user"></param>
    /// <param name="targetKey"></param>
    /// <returns></returns>
    public int GetFootprints(Transform user, string targetKey)
    {
        var uPoint = _naviMap.Where(point => !point.IsNoEntry).OrderBy(point => Vector3.Distance(point.Pos, user.position)).FirstOrDefault();
        if (uPoint == null || !uPoint.FootprintDic.ContainsKey(targetKey)) { return 0; }        
        return uPoint.FootprintDic[targetKey];
    }
}
