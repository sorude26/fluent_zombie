using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
/// <summary>
/// �U���}�b�v
/// </summary>
public class NavigationMap
{
    private int _power = default;
    private NaviPoint _currentTarget = default;
    private Thread _therad = default;
    private List<NaviPoint> _naviMap = default;
    private SearchMap<NaviPoint> _searchMap = new SearchMap<NaviPoint>();
    /// <summary> �U���_���X�g </summary>
    public List<NaviPoint> NaviMap { get { return _naviMap; } }
    public NavigationMap(List<NaviPoint> naviMap)
    {
        _naviMap = naviMap;
    }
    /// <summary>
    /// �T������
    /// </summary>
    /// <param name="targetKey"></param>
    private void MakeFootprints(string targetKey)
    {
        _searchMap.ResetFootprints(targetKey);
        _searchMap.StartMakeFootprints(_currentTarget, targetKey, _power);
    }
    /// <summary>
    /// �w��Ώۂ̒T��������ʃX���b�h�ōs��
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
    /// ���[�U�[�̈ړ�������Ԃ�
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
    /// ���[�U�[�̌��n�_�̑��Ղ�Ԃ�
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
