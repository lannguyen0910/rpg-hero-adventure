using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakerManager : MonoBehaviour
{
    Dictionary<int, EventTaker> eventTakers;

    private void Awake()
    {
        eventTakers = new Dictionary<int, EventTaker>();
    }

    public void addTaker(int code, EventTaker taker)
    {
        eventTakers.Add(code, taker);
    }

    public bool containTaker(int code)
    {
        return eventTakers.ContainsKey(code);    
    }

    public EventTaker getTaker(int code)
    {
        return eventTakers[code];
    }
}
