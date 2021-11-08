using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerManager : MonoBehaviour
{
    Dictionary<int, EventDealer> eventDealers;

    private void Awake()
    {
        eventDealers = new Dictionary<int, EventDealer>();
    }

    public void addDealer(int code, EventDealer dealer)
    {
        eventDealers.Add(code, dealer);
    }

    public void process(GameObject source, Collider2D destination)
    {
        foreach (EventDealer dealer in eventDealers.Values)
        {
            dealer.process(source, destination);
        }
    }
}
