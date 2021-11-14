using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public GameObject player;

    bool ready = false;

    void Update()
    {
        if (!ready) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("HomeScene");
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
}
