using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageTaker : EventTaker
{
    [SerializeField]
    float multiplier = 1;

    PlayerStatus status;

    new protected void Start()
    {
        eventCode = Global.DAMAGE_CODE;
        base.Start();
        
        status = gameObject.GetComponent<PlayerStatus>();
    }

    public override void Process(GameObject source, VariableDictionary variables)
    {
        GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.GETHIT_AUDIO_CODE);
        status.healthPoint -= (float)variables[Global.DAMAGE_NAME] * multiplier;
    }

    public void SetMultiplier(float multiplier)
    {
        this.multiplier = multiplier;
    }
}
