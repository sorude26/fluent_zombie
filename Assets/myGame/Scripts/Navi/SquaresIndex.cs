using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一元配列でのマス目のindex数を扱う
/// </summary>
public class SquaresIndex 
{
    /// <summary> 横方向の最大index数 </summary>
    private int _maxHorizontal;
    /// <summary> 全体の最大index数 </summary>
    private int _maxIndex;
    public SquaresIndex(int horizontal, int vertical)
    {
        _maxHorizontal = horizontal;
        _maxIndex = horizontal * vertical;
    }    
    /// <summary>
    /// 周囲八方向のIndexを返す
    /// </summary>
    /// <param name="index">指定点</param>
    /// <returns></returns>
    public IEnumerable<int> GetNeighor(int index)
    {
        //前段
        if (index >= _maxHorizontal)
        {
            foreach (int neighor in GetLeftMiddleRight(index - _maxHorizontal))
            {
                yield return neighor;
            }
        }
        //中段
        if (index % _maxHorizontal > 0)
        {
            yield return index - 1;  //左
        }
        if (index % _maxHorizontal < _maxHorizontal - 1)
        {
            yield return index + 1;  //右
        }
        yield return index;
        //後段
        if (index + _maxHorizontal < _maxIndex)
        {
            foreach (int neighor in GetLeftMiddleRight(index + _maxHorizontal))
            {
                yield return neighor;
            }
        }
    }
    /// <summary>
    /// 周囲四方向のIndexを返す
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public IEnumerable<int> GetNeighorCross(int index)
    {
        //前段
        if (index >= _maxHorizontal)
        {
            yield return index - _maxHorizontal;
        }
        //中段
        if (index % _maxHorizontal > 0)
        {
            yield return index - 1;  //左
        }
        if (index % _maxHorizontal < _maxHorizontal - 1)
        {
            yield return index + 1;  //右
        }
        //後段
        if (index + _maxHorizontal < _maxIndex)
        {
            yield return index + _maxHorizontal;
        }
    }
    /// <summary>
    /// 指定点と左右のIndexを返す
    /// </summary>
    /// <param name="index">指定点</param>
    /// <returns></returns>
    public IEnumerable<int> GetLeftMiddleRight(int index)
    {
        if (index % _maxHorizontal > 0)
        {
            //左
            yield return index - 1;
        }
        //中央
        yield return index;
        if (index % _maxHorizontal < _maxHorizontal - 1)
        {
            //右
            yield return index + 1;
        }
    }
}
