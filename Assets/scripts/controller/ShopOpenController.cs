using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpenController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject shopMenu;

    bool ready = false;

    void Update()
    {
        if (!ready) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Global.SetPlayerControlTo(player, false);
            shopMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.gameObject == player)
        {
            ready = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.gameObject == player)
        {
            ready = false;
        }
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
