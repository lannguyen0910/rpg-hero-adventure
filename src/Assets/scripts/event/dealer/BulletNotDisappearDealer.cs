using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNotDisappearDealer : EventDealer
{

    new void Start()
    {
        eventCode = Global.BULLET_DISAPPEAR_CODE;
        base.Start();
    }

    public override void Process(GameObject source, Collider2D destination)
    {
        if (!destination.isTrigger && destination.gameObject != source && destination.gameObject.name != "Colliders")
        {
            gameObject.AddComponent<BulletDisappearEffect>();
        }
    }
}
