using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    Dictionary<int, EventEffect> eventEffects;

    private void Awake()
    {
        eventEffects = new Dictionary<int, EventEffect>();
    }

    public void AddEffect(int code, EventEffect effect)
    {
        eventEffects.Add(code, effect);
    }

    public void RemoveEffect(int code)
    {
        if (eventEffects.ContainsKey(code))
        {
            eventEffects.Remove(code);
        }
    }

    public void Process(GameObject source)
    {
        foreach (EventEffect effect in eventEffects.Values)
        {
            effect.Process(source);
        }
    }
}
