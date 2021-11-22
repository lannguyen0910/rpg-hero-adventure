using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] audios = new GameObject[10];

    
    // Update is called once per frame
    void Update()
    {
        //if (!audios[0].GetComponent<AudioSource>().isPlaying) audios[0].GetComponent<AudioSource>().Play();
    }

    public void PlayAudio(int type)
    {
        audios[type].GetComponent<AudioSource>().Play();
    }

    public void StopAudio(int type)
    {
        audios[type].GetComponent<AudioSource>().Stop();
    }
}
