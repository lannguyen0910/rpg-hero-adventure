using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuffManager
{
    static Dictionary<int, Buff> buffDict = new Dictionary<int, Buff>();
    static List<int> buffList = new List<int>();
    static int n = 0;

    static BuffManager()
    {
        // Add instances
        Buff prototype;
        prototype = new HealthPointBuff();
        prototype = new DamageBuff();
    }

    public static Buff GetBuff(int code)
    {
        return buffDict[code];
    }

    public static void AddBuff(int code, Buff buff)
    {
        buffDict.Add(code, buff);
        buffList.Add(code);
        n++;
    }

    static HashSet<int> activeSpecialBuffs = new HashSet<int>();
    static List<int> currentBuffList = new List<int>();

    public static void Reset()
    {
        activeSpecialBuffs.Clear();
    }

    public static List<Buff> GetRandomBuffs()
    {
        System.Random rand = new System.Random();
        List<Buff> result = new List<Buff>();
        currentBuffList.Clear();

        int count = 0;
        while (count < 2)
        {
            int code = buffList[rand.Next(n)];
            if (activeSpecialBuffs.Contains(code)) continue;
            result.Add(buffDict[code]);
            currentBuffList.Add(code);
            count++;
        }
        return result;
    }

    public static void ChooseBuff(int index)
    {
        // Can only have 1 special buff each
        if (currentBuffList[index] > 100)
            activeSpecialBuffs.Add(currentBuffList[index]);
    }
}
