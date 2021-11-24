using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.BACKGROUND_AUDIO_CODE);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerStorage.SaveData();
            SceneManager.LoadScene("TitleScene");
        }
    }

}
