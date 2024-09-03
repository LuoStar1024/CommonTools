using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsBezier
{
    /// <summary>
    /// 获取贝塞尔曲线
    /// </summary>
    /// <param name="ctrlPosList">贝塞尔曲线控制点坐标</param>
    /// <param name="percison">精度，需要计算的该条贝塞尔曲线上的点的数目</param>
    /// <returns>该条贝塞尔曲线上的点</returns>
    public static List<Vector3> GetBezierPos(List<Vector3> ctrlPosList,int percison)
    {
        var result = new List<Vector3>();

        int order = ctrlPosList.Count; // 贝塞尔曲线控制点数目（阶数为数目-1）

        if (order < 2)
        {
            // 控制点不能小于2
            return result;
        }

        // 杨辉三角数据
        var yangHui = GetYangHuiTriangle(order);
        
        // 计算坐标
        for (int i = 0; i < percison; i++)
        {
            float t = i * 1.0f / percison;
            float tempX = 0;
            float tempY = 0;

            for (int j = 0; j < order; j++)
            {
                tempX += Mathf.Pow(1 - t, order - j - 1) * ctrlPosList[j].x * Mathf.Pow(t, j) * yangHui[j];
                tempY += Mathf.Pow(1 - t, order - j - 1) * ctrlPosList[j].y * Mathf.Pow(t, j) * yangHui[j];
            }
            
            result.Add(new Vector3(tempX, tempY));
        }
        
        return result;
    }

    /// <summary>
    /// 获取杨辉三角对应阶数的值
    /// </summary>
    /// <param name="number">杨辉三角的阶数</param>
    /// <returns>杨辉三角对应阶数的值</returns>
    public static List<int> GetYangHuiTriangle(int num)
    {
        var yangHui = new List<int>();

        if (num == 1)
        {
            yangHui.Add(1);
        }
        else
        {
            yangHui.Add(1);
            yangHui.Add(1);

            for (int i = 3; i <= num; i++)
            {
                var t = new List<int>();
                for (int j = 0; j < i - 1; j++)
                {
                    t.Add(yangHui[j]);
                }
                
                yangHui.Add(1);
                for (int j = 0; j < i - 2; j++)
                {
                    yangHui[j + 1] = t[j] + t[j + 1];
                }
            }
        }

        for (int i = 0; i < yangHui.Count; i++)
        {
            Debug.Log(yangHui[i]);
        }
        Debug.Log("xxxxxxxxxxxxxxxxx");
        return yangHui;
    }
}
