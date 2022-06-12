using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ミッションを統括管理するクラス
/// </summary>
public class MissionManager : MonoBehaviour
{
    [SerializeField, Header("全ミッション")]
    private MissionContainer[] _missionContainers = default;
    [SerializeField]
    private float _waitSeconds = 0.5f;
    private MissionContainer _currntMission = null;
    private WaitForSeconds _wait = default;
    private bool _isStartMission = false;
    public bool IsGameEnd { get; set; }
    /// <summary>
    /// ミッション管理を開始する
    /// </summary>
    /// <param name="targetMission"></param>
    public void StartMission(int targetMission)
    {
        if (_isStartMission || targetMission < 0 || targetMission >= _missionContainers.Length) { return; }
        _currntMission = _missionContainers[targetMission];
        _wait = new WaitForSeconds(_waitSeconds);
        _isStartMission = true;
        StartCoroutine(MissionExecution());
    }
    /// <summary>
    /// ミッション実行中処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator MissionExecution()
    {
        while (!IsGameEnd)
        {
            _currntMission.CheckMissionStart();
            yield return _wait;
        }
    }
}
