using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviPoint : IMapPoint<NaviPoint>
{
    public Vector3 Pos { get; }
    public int IndexID { get; }
    public bool IsNoEntry { get; set; }
    public List<NaviPoint> ConnectPoint { get; set; } = new List<NaviPoint>();
    public Dictionary<string, int> FootprintDic { get; set; } = new Dictionary<string, int>();
    public NaviPoint(Vector3 pos, int id)
    {
        Pos = pos;
        IndexID = id;
    }
}