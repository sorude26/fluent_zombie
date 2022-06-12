using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGans : MonoBehaviour
{
    [SerializeField, Tooltip("ïêäÌÇÃîzóÒ")] GameObject[] _gans;
    int _selectedIndex = 0;
    GameObject before;

    void Start()
    {
        var gan = _gans[_selectedIndex];
        gan.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (_selectedIndex - 1 < 0) { _selectedIndex = _gans.Length - 1; }
            else { _selectedIndex--; }
            LeftSelectGan();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(_selectedIndex +1 >= _gans.Length) { _selectedIndex = 0; }
            else { _selectedIndex++; }
            SelectGan();
        }
        
    }

    private void SelectGan()//âEâÒÇË
    {
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
    private void LeftSelectGan()//ç∂âÒÇË
    {
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
