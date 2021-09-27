using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayersCounter
{
    static int nowLayer = 1;

    public static int GetNewLayer()
    {
        nowLayer++;
        return nowLayer;
    }
}
