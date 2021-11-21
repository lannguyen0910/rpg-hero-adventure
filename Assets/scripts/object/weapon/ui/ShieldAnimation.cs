using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimation : MonoBehaviour
{
    Animator anim;

    float shieldDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldDelay < Global.EPS)
        {
            anim.SetBool("isShielding", false);            
        }
    }

    void FixedUpdate()
    {
        if (shieldDelay > Global.EPS)
        {
            shieldDelay -= Time.deltaTime;
        }
    }

    public void SetShieldAnim()
    {
        anim.SetBool("isShielding", true);
        shieldDelay = 1f;
    }
}
