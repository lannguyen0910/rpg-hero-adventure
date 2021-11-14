using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateEnterController : MonoBehaviour
{
    public GameObject player;

    bool ready = false;

    void Update()
    {
        if (!ready) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("PlayScene");
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
