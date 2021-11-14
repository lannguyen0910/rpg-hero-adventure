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

    public void addEffect(int code, EventEffect effect)
    {
        eventEffects.Add(code, effect);
    }

    public void process(GameObject source)
    {
        foreach (EventEffect effect in eventEffects.Values)
        {
            effect.process(source);
        }
    }
}
