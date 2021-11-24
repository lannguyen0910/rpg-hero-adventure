using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    GameObject player;
    PlayerStatus status;
    Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
            if (player != null)
                status = player.GetComponent<PlayerStatus>();
            return;
        }

        healthBar.value = status.healthPoint / status.maxHealthPoint;
    }
}
