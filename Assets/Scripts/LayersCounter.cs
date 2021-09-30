using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayersCounter
{
    static int nowstep = 5;
    static int nowLayerX = 0;
    static int nowLayerY = 0;
    static int nowLayerZ = 0;
    public static int depth = 2;

    public static Vector3Int GetNewLayer()
    {
        nowLayerX++;
        if (nowLayerX > 10)
        {
            nowLayerX = 0;
            nowLayerY++;
            if (nowLayerY > 10)
            {
                nowLayerY = 0;
                nowLayerZ++;

            }
        }
        return new Vector3Int(nowLayerX,nowLayerY,nowLayerZ);
    }
    public static void GetNewStep()
    {
        nowstep--;
    }
    public static int GetStep()
    {
        
        return nowstep;
    }
}
