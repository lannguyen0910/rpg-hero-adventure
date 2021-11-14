using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public GameObject source;

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

    // Update is called once per frame
    void Update()
    {
        effects.process(source);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dealers.process(source, collision);
    }

    public void setSource(GameObject gameObject)
    {
        source = gameObject;
    }
}
