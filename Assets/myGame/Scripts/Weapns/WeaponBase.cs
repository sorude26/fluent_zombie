using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����̊��N���X
/// </summary>
public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField]
    protected WeaponParameter _parameter = default;
    protected CharacterParameter _owner = default;
    /// <summary>
    /// ���L�҂�ݒ肵�A����������
    /// </summary>
    /// <param name="owner"></param>
    public virtual void Initialize(CharacterParameter owner)
    {
        _owner = owner;
    }
    /// <summary>
    /// ���̕���̃_���[�W��Ԃ�
    /// </summary>
    /// <returns></returns>
    protected virtual Damage GetDamage()
    {
        //Owner�̃p�����[�^�ϓ��Ń_���[�W���ϓ������new����
        return new Damage(_parameter.Damage + _owner.DefaultPower);
    }
    /// <summary>
    /// �U�����s��
    /// </summary>
    public abstract void Attack();
}
