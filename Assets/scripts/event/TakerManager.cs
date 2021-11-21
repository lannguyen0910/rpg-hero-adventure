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

    public void AddTaker(int code, EventTaker taker)
    {
        if (eventTakers.ContainsKey(code))
            eventTakers[code] = taker;
        else
            eventTakers.Add(code, taker);
    }

    public void RemoveTaker(int code)
    {
        if (eventTakers.ContainsKey(code))
        {
            eventTakers.Remove(code);
        }
    }

    public bool ContainsTaker(int code)
    {
        return eventTakers.ContainsKey(code);    
    }

    public EventTaker GetTaker(int code)
    {
        return eventTakers[code];
    }
}
