using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalConstraints
{
    public static int DAMAGE_CODE = 1;
    public static float EPS = 0.00001f;


    public static float OFFSET = 0.1f;

    public static float calDistance(Vector3 a, Vector3 b)
    {
        return (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);
    }
}
