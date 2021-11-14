using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public GameObject player;

    PlayerStatus status;
    Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        status = player.GetComponent<PlayerStatus>();
        healthBar = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = status.healthPoint / 100f;
    }
}
