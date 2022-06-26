using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���V�[�����̃f�[�^������
/// </summary>
public class GameData
{
    private static GameData instance;
    public static GameData Instance 
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
                instance.CountData = new Dictionary<int, int>();
            }
            return instance;
        }
    }
    /// <summary> �Q�[�����̑S�J�E���g���f�[�^ </summary>
    public Dictionary<int,int> CountData { get; private set; }
    /// <summary> �Q�[�����̎��� </summary>
    public float GameTime { get=> Time.time; }
    /// <summary> �O�������Instance����h�� </summary>
    private GameData() { }
    /// <summary>
    /// �w��ID�̃J�E���g�𑝂₷
    /// </summary>
    /// <param name="id"></param>
    /// <param name="count"></param>
    public void AddCount(int id,int count = 1)
    {
        if (!CountData.ContainsKey(id))
        {
            CountData.Add(id, count);
        }
        else
        {
            CountData[id] += count;
        }
    }
    /// <summary>
    /// �S�J�E���g�����Z�b�g����
    /// </summary>
    public void ResetCountData()
    {
        CountData.Clear();
    }
}
