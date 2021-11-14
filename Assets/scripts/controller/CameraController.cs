using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public float minPos;
    public float maxPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        Vector3 newPos = new Vector3(transform.position.x, player.transform.position.y, -10);
        if (newPos.y > maxPos) newPos.y = maxPos;
        if (newPos.y < minPos) newPos.y = minPos;
        transform.position = newPos;
    }
}
