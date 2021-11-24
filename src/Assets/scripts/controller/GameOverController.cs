using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.LOSE_AUDIO_CODE);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("HomeScene");
        }
    }
}
