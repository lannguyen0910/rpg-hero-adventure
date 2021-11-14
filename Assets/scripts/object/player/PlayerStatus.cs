using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public float healthPoint = 100f;
    public float moveSpeed = 5f;
    public float attackSpeed = 40f / 60f;

    public int curDirection = 0;
    public float actionDelay = 0;

    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (healthPoint <= 0)
        {
            SceneManager.LoadScene("HomeScene");
        }
    }

    void FixedUpdate()
    {
        if (actionDelay > 0)
        {
            actionDelay -= Time.deltaTime;
            anim.SetFloat("actionDelay", actionDelay);
        }
        else
            anim.SetInteger("actionType", -1);
    }
}
