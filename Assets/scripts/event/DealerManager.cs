using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerManager : MonoBehaviour
{
    Dictionary<int, EventDealer> eventDealers;

    List<int> removeQueue = new List<int>();

    private void Awake()
    {
        eventDealers = new Dictionary<int, EventDealer>();
    }

    public void AddDealer(int code, EventDealer dealer)
    {
        if (eventDealers.ContainsKey(code))
            eventDealers[code] = dealer;
        else
            eventDealers.Add(code, dealer);
    }

    public void RemoveDealer(int code)
    {
        if (eventDealers.ContainsKey(code))
        {
            removeQueue.Add(code);
        }
    }

    public EventDealer GetDealer(int code)
    {
        if (eventDealers.ContainsKey(code))
            return eventDealers[code];
        else
            return null;
    }

    public void Process(GameObject source, Collider2D destination)
    {
        foreach (int code in removeQueue)
        {
            eventDealers[code].RemoveSelf();
            eventDealers.Remove(code);
        }
        removeQueue.Clear();

        foreach (EventDealer dealer in eventDealers.Values)
        {
            dealer.Process(source, destination);
        }
    }
}
