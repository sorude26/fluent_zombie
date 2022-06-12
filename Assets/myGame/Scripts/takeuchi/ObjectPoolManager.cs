using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private const int DEFAULT_POOL_COUNT = 10;
    public const int DEFAULT_LIMIT_COUNT = 500;
    private static ObjectPoolManager instance;
    public static ObjectPoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                var poolObj = new GameObject("PoolBase");
                instance = poolObj.AddComponent<ObjectPoolManager>();
                instance._keysDic = new Dictionary<string, int>();
                instance._objectDic = new Dictionary<int, List<GameObject>>();
                DontDestroyOnLoad(poolObj);
            }
            return instance;
        }
    }
    private Dictionary<string, int> _keysDic = default;
    private Dictionary<int, List<GameObject>> _objectDic = default;
    public void CreatePool(GameObject poolObject)
    {
        if (_keysDic.ContainsKey(poolObject.name))
        {
            return;
        }
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < DEFAULT_POOL_COUNT; i++)
        {
            var obj = Instantiate(poolObject, this.transform);
            obj.SetActive(false);
            list.Add(obj);
        }
        _objectDic.Add(_keysDic.Count, list);
        _keysDic.Add(poolObject.name, _keysDic.Count);
    }
    public GameObject Use(GameObject useObject)
    {
        if (!_keysDic.ContainsKey(useObject.name))
        {
            CreatePool(useObject);
        }
        foreach (var listObj in _objectDic[_keysDic[useObject.name]])
        {
            if (listObj.activeInHierarchy)
            {
                continue;
            }
            listObj.SetActive(true);
            return listObj;
        }
        var obj = Instantiate(useObject, this.transform);
        _objectDic[_keysDic[useObject.name]].Add(obj);
        return obj;
    }
    public GameObject Use(GameObject useObject, Vector3 pos)
    {
        var obj = Use(useObject);
        obj.transform.position = pos;
        return obj;
    }
    public bool LimitUse(GameObject useObject,Vector3 pos,int limitCount = DEFAULT_LIMIT_COUNT)
    {
        if (!_keysDic.ContainsKey(useObject.name))
        {
            CreatePool(useObject);
        }
        if (_objectDic[_keysDic[useObject.name]].Count >= limitCount && limitCount > DEFAULT_POOL_COUNT)
        {
            return false;
        }
        Use(useObject,pos);
        return true;
    }
}
