using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public static NavigationManager Instance { get; private set; }
    [SerializeField]
    private NavigationMapCreater _mapCreater = default;
    [SerializeField]
    private float _updateIntervalTime = 1f;
    [SerializeField]
    private float _naviIntervalTime = 0.2f;
    [SerializeField]
    private Transform _defaultTarget = default;
    [SerializeField]
    private int _range = 100;
    [SerializeField]
    private LayerMask _obstacleLayer = default;
    [SerializeField]
    private int _maxRayCount = 500;
    private float _rayRange = 5f;
    private WaitForSeconds _updateInterval = default;
    private WaitForSeconds _naviInterval = default;
    private NavigationMap _navMap = default;
    private List<Transform> _naviTarget = new List<Transform>();
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        StartNavigation();
    }
    private void StartNavigation()
    {
        _updateInterval = new WaitForSeconds(_updateIntervalTime);
        _naviInterval = new WaitForSeconds(_naviIntervalTime);
        _navMap = _mapCreater.CreateMap();
        RequestTargetNavigation(_defaultTarget);
        StartCoroutine(NavigationUpdate());
    }
    private IEnumerator NavigationUpdate()
    {
        while (true)
        {
            yield return PointUpDate();
            foreach (Transform target in _naviTarget)
            {
                _navMap.MakeFootprints(target, target.gameObject.name, _range);
                yield return _naviInterval;
            }
            yield return _updateInterval;
        }
    }
    private IEnumerator PointUpDate()
    {
        if (_navMap is null)
        {
            yield break;
        }
        int count = _maxRayCount;
        foreach (var navMap in _navMap.NaviMap)
        {
            navMap.IsNoEntry = Physics.Raycast(navMap.Pos, Vector3.up, _rayRange, _obstacleLayer);
            count--;
            if (count < 0)
            {
                count = _maxRayCount;
                yield return null;
            }
        }
    }
    public void RequestTargetNavigation(Transform target)
    {
        if (_naviTarget.Contains(target))
        {
            return;
        }
        _naviTarget.Add(target);
    }
    public Vector3 GetMoveDir(Transform user)
    {
        if (_defaultTarget is null)
        {
            return Vector3.zero;
        }
        return GetMoveDir(user, _defaultTarget.gameObject.name);
    }
    public Vector3 GetMoveDir(Transform user, string targetKey)
    {
        if (_navMap is null)
        {
            return Vector3.zero;
        }
        return _navMap.GetMoveDir(user,targetKey);
    }
    public int GetPoint(Transform user, string targetKey)
    {
        if (_navMap is null)
        {
            return 0;
        }
        return _navMap.GetFootprints(user,targetKey);
    }
}
