using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGans : MonoBehaviour
{
    [SerializeField, Tooltip("武器の配列")] 
    GameObject[] _gans;
    [Tooltip("選択中の武器")] 
    int _selectedIndex = 0;
    [Tooltip("選択前の武器")] 
    GameObject before;
    [Tooltip("配列操作用")]
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

    public void SelectGan()//右回り
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
    public void LeftSelectGan()//左回り
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
