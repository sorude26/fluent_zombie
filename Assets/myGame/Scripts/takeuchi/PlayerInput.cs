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
    private static bool _initialized = true;
    /// <summary> ���͕��� </summary>
    private Vector2 _inputVector = default;
    /// <summary> ���͒��� </summary>
    private Dictionary<InputType, Action> _onEnterInputDic = new Dictionary<InputType, Action>();
    /// <summary> ���͒� </summary>
    private Dictionary<InputType, Action> _onStayInputDic = new Dictionary<InputType, Action>();
    /// <summary> ���͉��� </summary>
    private Dictionary<InputType, Action> _onExitInputDic = new Dictionary<InputType, Action>();
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
    public static Vector2 InputVector
    {
        get
        {
            if (_instance == null || !_initialized)
            {
                return Vector2.zero;
            }
            return _instance._inputVector;
        }
    }

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
            if (Input.GetButtonDown("Fire1"))
            {
                _onEnterInputDic[InputType.Fire1]?.Invoke();
            }
            _onStayInputDic[InputType.Fire1]?.Invoke();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            _onExitInputDic[InputType.Fire1]?.Invoke();
        }
        if (Input.GetButton("Fire2"))
        {
            if (Input.GetButtonDown("Fire2"))
            {
                _onEnterInputDic[InputType.Fire2]?.Invoke();
            }
            _onStayInputDic[InputType.Fire2]?.Invoke();
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            _onExitInputDic[InputType.Fire2]?.Invoke();
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
        for (int i = 0; i < Enum.GetValues(typeof(InputType)).Length; i++)
        {
            _onEnterInputDic.Add((InputType)i, null);
            _onStayInputDic.Add((InputType)i, null);
            _onExitInputDic.Add((InputType)i, null);
        }
    }
    private void ResetInput()
    {
        if (_instance == null || !_initialized) { return; }
        for (int i = 0; i < Enum.GetValues(typeof(InputType)).Length; i++)
        {
            _instance._onEnterInputDic[(InputType)i] = null;
            _instance._onStayInputDic[(InputType)i] = null;
            _instance._onExitInputDic[(InputType)i] = null;
        }
        _initialized = false;
    }
    public static void SetEnterInput(InputType type, Action action)
    {
        if (!_initialized) { return; }
        Instance._onEnterInputDic[type] += action;
    }
    public static void LiftEnterInput(InputType type, Action action)
    {
        if (!_initialized) { return; }
        Instance._onEnterInputDic[type] -= action;
    }
    public static void SetStayInput(InputType type, Action action)
    {
        if (!_initialized) { return; }
        Instance._onStayInputDic[type] += action;
    }
    public static void LiftStayInput(InputType type, Action action)
    {
        if (_instance == null || !_initialized) { return; }
        _instance._onStayInputDic[type] -= action;
    }
    public static void SetExitInput(InputType type, Action action)
    {
        if (_instance == null || !_initialized) { return; }
        _instance._onExitInputDic[type] += action;
    }
    public static void LiftExitInput(InputType type, Action action)
    {
        if (_instance == null || !_initialized) { return; }
        _instance._onExitInputDic[type] -= action;
    }
}
