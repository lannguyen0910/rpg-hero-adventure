using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField]
    GameObject source;

    DealerManager dealers;
    TakerManager takers;
    EffectManager effects;

    // Start is called before the first frame update
    void Start()
    {
        dealers = gameObject.GetComponent<DealerManager>();
        takers = gameObject.GetComponent<TakerManager>();
        effects = gameObject.GetComponent<EffectManager>();
    }

    void FixedUpdate()
    {
        effects.Process(source);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dealers.Process(source, collision);
    }

    public void SetSource(GameObject gameObject)
    {
        source = gameObject;
    }
}
