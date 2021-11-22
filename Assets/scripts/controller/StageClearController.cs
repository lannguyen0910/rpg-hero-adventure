using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearController : MonoBehaviour
{
    [SerializeField]
    GameObject buffMenu;

    float delay = 0f;

    void Start()
    {
        GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.VICTORY_AUDIO_CODE);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        delay += Time.deltaTime;

        if (Global.IsGreaterEqual(delay, 3f))
        {
            if (buffMenu != null) buffMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
