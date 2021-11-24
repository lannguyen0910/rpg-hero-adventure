using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    Dictionary<int, EventEffect> eventEffects;

    List<int> removeQueue = new List<int>();

    private void Awake()
    {
        eventEffects = new Dictionary<int, EventEffect>();
    }

    public void AddEffect(int code, EventEffect effect)
    {
        if (eventEffects.ContainsKey(code))
            eventEffects[code] = effect;
        else
        {
            eventEffects.Add(code, effect);
        }
    }

    public void RemoveEffect(int code)
    {
        if (eventEffects.ContainsKey(code))
        {
            removeQueue.Add(code);
        }
    }

    public EventEffect GetEffect(int code)
    {
        if (eventEffects.ContainsKey(code))
            return eventEffects[code];
        else
            return null;
    }

    public void Process(GameObject source)
    {
        foreach (int code in removeQueue)
        {
            eventEffects[code].RemoveSelf();
            eventEffects.Remove(code);
        }
        removeQueue.Clear();

        foreach (EventEffect effect in eventEffects.Values)
        {
            effect.Process(source);
        }
    }
}
