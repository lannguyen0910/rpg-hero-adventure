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
    public static float DEFAULT_PLAYER_POS_X = 7;
    public static float DEFAULT_PLAYER_POS_Y = 1;

    // Move code
    public static int MOVE_LEFT = (int)KeyCode.LeftArrow;
    public static int MOVE_RIGHT = (int)KeyCode.RightArrow;
    public static int MOVE_UP = (int)KeyCode.UpArrow;
    public static int MOVE_DOWN = (int)KeyCode.DownArrow;

    // Weapon code
    public static int MELEE_WEAPON = 0;
    public static int MAGIC_WEAPON = 1;

    public static int WEAPON_CHANGE = (int)KeyCode.LeftShift;
    public static int WEAPON_ACTION_1 = (int)KeyCode.C;
    public static int WEAPON_ACTION_2 = (int)KeyCode.X;
    public static int WEAPON_ACTION_3 = (int)KeyCode.Z;

    public static int MELEE_ATTACK = 0;
    public static int MELEE_GUARD = 1;
    public static int MELEE_DASH = 2;

    public static int MAGIC_CHARGE = 0;
    public static int MAGIC_CAST = 999;

    // Event code
    public static int INVINCIBLE_CODE = 10001;
    public static int GUARD_CODE = 10002;

    public static int DAMAGE_CODE = 001;
    public static int SLASH_CODE = 051;

    public static int BULLET_DISAPPEAR_CODE = 101;
    public static int BULLET_BOUNCE_CODE = 102;
    public static int BULLET_CODE = 201;
    public static int EXPLOSION_CODE = 202;

    // Buff code
    public static int HP_BUFF_CODE = 1;
    public static int DAMAGE_BUFF_CODE = 2;
    public static int RANGE_BUFF_CODE = 3;
    public static int BULLET_SPEED_BUFF_CODE = 4;
    public static int BULLET_THROUGH_BUFF_CODE = 101;
    public static int BULLET_HOLMING_BUFF_CODE = 102;

    // Audio code
    public static int BACKGROUND_AUDIO_CODE = 0;
    public static int HOVER0_AUDIO_CODE = 1;
    public static int HOVER1_AUDIO_CODE = 2;
    public static int BUY_AUDIO_CODE = 3;
    public static int CLICK_AUDIO_CODE = 4;
    public static int SLASH_AUDIO_CODE = 5;
    public static int CHARGE_AUDIO_CODE = 6;
    public static int CAST_AUDIO_CODE = 7;
    public static int HIT_AUDIO_CODE = 8;
    public static int GETHIT_AUDIO_CODE = 9;
    public static int VICTORY_AUDIO_CODE = 10;
    public static int LOSE_AUDIO_CODE = 11;

    // Variable name
    public static string DAMAGE_NAME = "damage";

    // Other constants
    public static float INF = 1000000000f;
    public static float EPS = 0.0001f;
    public static float PI = 3.1416f;
    public static float OFFSET = 0.1f;

    public static Vector2 VECTOR_UNIT = new Vector2(0, -1);
    public static float ANGLE_PER_DIRECTION = 45;

    // Global function

    public static bool IsGreaterEqual(float a, float b)
    {
        return Mathf.Abs(a - b) < EPS || a > b;
    }

    public static bool IsEqual(float a, float b)
    {
        return Mathf.Abs(a - b) < EPS;
    }

    public static float CalculateDistance(Vector3 a, Vector3 b)
    {
        return (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);
    }

    public static float CalculateManhattanDistance(Vector3 a, Vector3 b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    public static float CalculateAngleBetween(Vector2 a, Vector2 b)
    {
        return Vector2.Angle(a, b);
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

    public static int NormalizeDirection(float angle)
    {
        for (int i = 0; i < PLAYER_DIRECTION_COUNT; i++)
        {
            float left = ANGLE_PER_DIRECTION * i - ANGLE_PER_DIRECTION / 2;
            float right = ANGLE_PER_DIRECTION * i + ANGLE_PER_DIRECTION / 2;
            if (IsGreaterEqual(right, angle) && IsGreaterEqual(angle, left))
                return i;
        }
        return 0;
    }

    public static int NormalizeDirection(float angle, bool flag)
    {
        for (int i = 0; i < PLAYER_DIRECTION_COUNT / 2; i++)
        {
            float left = 2 * ANGLE_PER_DIRECTION * i - ANGLE_PER_DIRECTION;
            float right = 2 * ANGLE_PER_DIRECTION * i + ANGLE_PER_DIRECTION;
            if (IsGreaterEqual(right, angle) && IsGreaterEqual(angle, left))
                return i;
        }
        return 0;
    }

    public static bool IsEqual(Vector3 cell, Vector3 position)
    {
        return IsEqual(CalculateManhattanDistance(cell, position), 0f);
    }

    public static void SetPlayerControlTo(GameObject player, bool flag)
    {
        player.GetComponent<PlayerMovementController>().enabled = flag;
        player.GetComponent<PlayerMeleeWeaponController>().enabled = flag;
        player.GetComponent<PlayerMagicWeaponController>().enabled = flag;
    }
}
