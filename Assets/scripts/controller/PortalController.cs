using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject player;

    public float nextCameraMinPos;
    public float nextCameraMaxPos;

    bool ready = false;

    void Update()
    {
        if (!ready) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
            GameObject camera = GameObject.Find("Main Camera");
            camera.GetComponent<CameraController>().minPos = nextCameraMinPos;
            camera.GetComponent<CameraController>().maxPos = nextCameraMaxPos;
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
