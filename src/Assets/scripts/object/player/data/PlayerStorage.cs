using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class PlayerStorage
{
    public static string path = Application.persistentDataPath + "/load.txt";

    public static int gold;

    static bool already = false;
    public static float baseHP = 100;
    public static int melee = 1;
    public static int magic = 1;
    public static int meleeSkill = 1;
    public static int magicSkill = 1;

    public static void LoadData()
    {
        if (already) return;
        already = true;

        StreamReader reader = new StreamReader(path);
        gold = int.Parse(reader.ReadLine());
        melee = int.Parse(reader.ReadLine());
        magic = int.Parse(reader.ReadLine());
        meleeSkill = int.Parse(reader.ReadLine());
        magicSkill = int.Parse(reader.ReadLine());
        reader.Close();
    }

    public static void SaveData()
    {
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(gold);
        writer.WriteLine(melee);
        writer.WriteLine(magic);
        writer.WriteLine(meleeSkill);
        writer.WriteLine(magicSkill);
        writer.Close();
    }
}
