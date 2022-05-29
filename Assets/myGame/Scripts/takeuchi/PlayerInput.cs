using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType
{
    /// <summary> 決定入力 </summary>
    Submit,
    /// <summary> キャンセル入力 </summary>
    Cancel,
    /// <summary> 移動入力 </summary>
    Move,
    /// <summary> 攻撃入力１ </summary>
    Fire1,
    /// <summary> 攻撃入力２ </summary>
    Fire2,
    /// <summary> 攻撃入力３ </summary>
    Fire3,
}
public class PlayerInput : MonoBehaviour
{
    private static PlayerInput _instance = default;
    /// <summary> 入力方向 </summary>
    private Vector2 _inputVector = default;
    /// <summary> 入力直後 </summary>
    private Dictionary<InputType, Action> _onEnterInputDic = default;
    /// <summary> 入力中 </summary>
    private Dictionary<InputType, Action> _onStayInputDic = default;
    /// <summary> 入力解除 </summary>
    private Dictionary<InputType, Action> _onExitInputDic = default;
    public static PlayerInput Instance 
    {
        get 
        {
            if (_instance == null)//nullならインスタンス化する
            {
                var obj = new GameObject("PlayerInput");
                var input = obj.AddComponent<PlayerInput>();
                input.Initialization();
                _instance = input;
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }
    /// <summary> 入力方向 </summary>
    public static Vector2 InputVector { get => Instance._inputVector; }
    
    private void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            _inputVector = Vector2.right * h + Vector2.up * v;
            _onEnterInputDic[InputType.Move]?.Invoke();
        }
        else if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            _inputVector = Vector2.zero;
            _onExitInputDic[InputType.Move]?.Invoke();
        }
    }
    /// <summary>
    /// 初期化処理を行う
    /// </summary>
    private void Initialization()
    {
        _onEnterInputDic = new Dictionary<InputType, Action>();
        _onStayInputDic = new Dictionary<InputType, Action>();
        _onExitInputDic = new Dictionary<InputType, Action>();
        for (int i = 0; i < Enum.GetValues(typeof(InputType)).Length; i++)
        {
            _onEnterInputDic.Add((InputType)i, () => { });
            _onStayInputDic.Add((InputType)i, () => { });
            _onExitInputDic.Add((InputType)i, () => { });
        }
    }
    public static void SetEnterInput(InputType type, Action action)
    {
        Instance._onEnterInputDic[type] += action;
    }
    public static void LiftEnterInput(InputType type, Action action)
    {
        Instance._onEnterInputDic[type] -= action;
    }
    public static void SetStayInput(InputType type, Action action)
    {
        Instance._onStayInputDic[type] += action;
    }
    public static void LiftStayInput(InputType type, Action action)
    {
        Instance._onEnterInputDic[type] -= action;
    }
    public static void SetExitInput(InputType type, Action action)
    {
        Instance._onExitInputDic[type] += action;
    }
    public static void LiftExitInput(InputType type, Action action)
    {
        Instance._onEnterInputDic[type] -= action;
    }
}
