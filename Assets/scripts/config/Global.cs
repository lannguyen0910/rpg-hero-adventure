using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    // Camera constants
    public static int CAMERA_X = 7;
    public static int CAMERA_Z = -10;
    public static int CAMERA_MIN_Y = 5;
    public static int CAMERA_MAX_Y = 11;

    // Map constants
    public static int MAP_WIDTH = 12;
    public static int MAP_HEIGHT = 12;

    // Player constants
    public static int PLAYER_DIRECTION_COUNT = 8;
    public static int PLAYER_DIRECTION_BREAKPOINT = 4;

    // Move code
    public static int MOVE_LEFT = (int)KeyCode.LeftArrow;
    public static int MOVE_RIGHT = (int)KeyCode.RightArrow;
    public static int MOVE_UP = (int)KeyCode.UpArrow;
    public static int MOVE_DOWN = (int)KeyCode.DownArrow;

    // Weapon code
    public static int MELEE_WEAPON = 0;
    public static int MAGIC_WEAPON = 1;

    public static int WEAPON_ACTION_1 = (int)KeyCode.C;
    public static int WEAPON_ACTION_2 = (int)KeyCode.X;
    public static int WEAPON_ACTION_3 = (int)KeyCode.Z;

    public static int MELEE_ATTACK = 1;
    public static int MELEE_GUARD = 2;
    public static int MELEE_DASH = 3;

    public static int MAGIC_FIRE_ATTACK = 1;
    public static int MAGIC_ICE_ATTACK = 2;
    public static int MAGIC__ATTACK = 3;

    // Event code
    public static int DAMAGE_CODE = 1;



    // Other constants
    public static float INF = 1000000000f;
    public static float EPS = 0.00001f;
    public static float PI = 3.1416f;
    public static float OFFSET = 0.1f;

    // Global function
    public static float CalculateDistance(Vector3 a, Vector3 b)
    {
        return (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);
    }

    public static bool AdjustDirection(ref int direction, int breakpoint)
    {
        if (direction > breakpoint)
        {
            direction -= (direction - breakpoint) * 2;
            return true;
        }
        return false;
    }
}
