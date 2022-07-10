using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private const int DEFAULT_BULLET_COUNT = 50;
    private static BulletPool instance;
    public static BulletPool Instance
    {
        get 
        { 
            if (instance == null)
            {
                var obj = new GameObject("BulletPool");
                instance = obj.AddComponent<BulletPool>();
                instance._keysDic = new Dictionary<string, int>();
                instance._bulletDic = new Dictionary<int, List<WeaponBullet>>();
            }
            return instance; 
        }
    }
    private Dictionary<string, int> _keysDic = default;
    private Dictionary<int,List<WeaponBullet>> _bulletDic = default;
    private void CreateBulletPool(WeaponBullet newBullet)
    {
        _keysDic.Add(newBullet.gameObject.name, _keysDic.Count);
        var bulletList = new List<WeaponBullet>();
        for (int i = 0; i < DEFAULT_BULLET_COUNT; i++)
        {
            var bullet = Instantiate(newBullet,transform);
            bullet.gameObject.SetActive(false);
            bulletList.Add(bullet);
        }
        _bulletDic.Add(_keysDic[newBullet.gameObject.name], bulletList);
    }
    public WeaponBullet GetBullet(WeaponBullet bullet)
    {
        if (!_keysDic.ContainsKey(bullet.gameObject.name))
        {
            CreateBulletPool(bullet); 
        }
        foreach (var poolBullet in _bulletDic[_keysDic[bullet.gameObject.name]])
        {
            if (poolBullet.gameObject.activeInHierarchy)
            {
                continue;
            }
            return poolBullet;
        }
        var newBullet = Instantiate(bullet, transform);
        newBullet.gameObject.SetActive(false);
        _bulletDic[_keysDic[bullet.gameObject.name]].Add(newBullet);
        return newBullet;
    }
}
