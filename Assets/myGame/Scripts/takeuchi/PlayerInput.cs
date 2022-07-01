using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType
{
    /// <summary> ������� </summary>
    Submit,
    /// <summary> �L�����Z������ </summary>
    Cancel,
    /// <summary> �ړ����� </summary>
    Move,
    /// <summary> �U�����͂P </summary>
    Fire1,
    /// <summary> �U�����͂Q </summary>
    Fire2,
    /// <summary> �U�����͂R </summary>
    Fire3,
}
public class PlayerInput : MonoBehaviour
{
    private static PlayerInput _instance = default;
    /// <summary> ���͕��� </summary>
    private Vector2 _inputVector = default;
    /// <summary> ���͒��� </summary>
    private Dictionary<InputType, Action> _onEnterInputDic = default;
    /// <summary> ���͒� </summary>
    private Dictionary<InputType, Action> _onStayInputDic = default;
    /// <summary> ���͉��� </summary>
    private Dictionary<InputType, Action> _onExitInputDic = default;
    public static PlayerInput Instance
    {
        get
        {
            if (_instance == null)//null�Ȃ�C���X�^���X������
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
    /// <summary> ���͕��� </summary>
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
        if (Input.GetButton("Fire1"))
        {
            _onEnterInputDic[InputType.Fire1]?.Invoke();
        }
    }
    private void OnDestroy()
    {
        ResetInput();
    }
    /// <summary>
    /// �������������s��
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
    private void ResetInput()
    {
        if (_instance == null) { return; }
        for (int i = 0; i < Enum.GetValues(typeof(InputType)).Length; i++)
        {
            _onEnterInputDic[(InputType)i] = null;
            _onStayInputDic[(InputType)i] = null;
            _onExitInputDic[(InputType)i] = null;
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
