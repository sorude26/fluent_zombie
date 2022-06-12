using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGans : MonoBehaviour
{
    [SerializeField, Tooltip("武器の配列")] GameObject[] _gans;
    [Tooltip("選択中の武器")] int _selectedIndex = 0;
    [Tooltip("選択前の武器")] GameObject before;

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

    private void SelectGan()//右回り
    {
        if (_selectedIndex + 1 >= _gans.Length) { _selectedIndex = 0; }
        else { _selectedIndex++; }

        var gan = _gans[_selectedIndex];
        gan.SetActive(true);
        if (_selectedIndex - 1 < 0)
        {
            before = _gans[_gans.Length - 1];
            before.SetActive(false);
        }
        else
        {
            before = _gans[_selectedIndex - 1];
            before.SetActive(false);
        }
    }
    private void LeftSelectGan()//左回り
    {
        if (_selectedIndex - 1 < 0) { _selectedIndex = _gans.Length - 1; }
        else { _selectedIndex--; }

        var gan = _gans[_selectedIndex];
        gan.SetActive(true);
        if (_selectedIndex + 1 >= _gans.Length)
        {
            before = _gans[0];
            before.SetActive(false);
        }
        else
        {
            before = _gans[_selectedIndex + 1];
            before.SetActive(false);
        }
    }
}
