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
    private float _waitStartCheckSeconds = 0.5f;
    [SerializeField]
    private float _waitClearCheckSeconds = 0.5f;
    private MissionContainer _currntMission = null;
    private WaitForSeconds _waitStartCheck = default;
    private WaitForSeconds _waitClearCheck = default;
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
        _waitStartCheck = new WaitForSeconds(_waitStartCheckSeconds);
        _waitClearCheck = new WaitForSeconds(_waitClearCheckSeconds);
        _isStartMission = true;
        StartCoroutine(StartMissionExecution());
        StartCoroutine(MissionExecution());
    }
    /// <summary>
    /// ミッション実行中処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartMissionExecution()
    {
        while (!IsGameEnd)
        {
            _currntMission.CheckMissionStart();
            yield return _waitStartCheck;
        }
    }
    /// <summary>
    /// クリアチェック処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator MissionExecution()
    {
        while (!IsGameEnd)
        {
            _currntMission.CheckMissionClear();
            yield return _waitClearCheck;
        }
    }
}
