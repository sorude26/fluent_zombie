using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGans : MonoBehaviour
{
    [SerializeField, Tooltip("����̔z��")] 
    GameObject[] _gans;
    [Tooltip("�I�𒆂̕���")] 
    int _selectedIndex = 0;
    [Tooltip("�I��O�̕���")] 
    GameObject before;
    [Tooltip("�z�񑀍�p")]
    const int INDEX_ONE = 1;

    void Start()
    {
        var gan = _gans[_selectedIndex];
        gan.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LeftSelectGan();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            SelectGan();
        }

    }

    public void SelectGan()//�E���
    {
        if (_selectedIndex + INDEX_ONE >= _gans.Length) { _selectedIndex = 0; }
        else { _selectedIndex++; }

        var gan = _gans[_selectedIndex];
        gan.SetActive(true);
        if (_selectedIndex - INDEX_ONE < 0)
        {
            before = _gans[_gans.Length - INDEX_ONE];
            before.SetActive(false);
        }
        else
        {
            before = _gans[_selectedIndex - INDEX_ONE];
            before.SetActive(false);
        }
    }
    public void LeftSelectGan()//�����
    {
        if (_selectedIndex - INDEX_ONE < 0) { _selectedIndex = _gans.Length - INDEX_ONE; }
        else { _selectedIndex--; }

        var gan = _gans[_selectedIndex];
        gan.SetActive(true);
        if (_selectedIndex + INDEX_ONE >= _gans.Length)
        {
            before = _gans[0];
            before.SetActive(false);
        }
        else
        {
            before = _gans[_selectedIndex + INDEX_ONE];
            before.SetActive(false);
        }
    }
}
