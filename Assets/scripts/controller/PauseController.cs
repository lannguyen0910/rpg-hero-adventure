using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    GameObject player;

    GameObject option0, option1;
    GameObject border;

    int currentOption;
    bool isPausing = false;

    void Start()
    {
        option0 = pauseMenu.transform.Find("Resume").gameObject;
        option1 = pauseMenu.transform.Find("Exit").gameObject;
        border = pauseMenu.transform.Find("SelectBorder").gameObject;
        currentOption = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
            return;
        }

        if (!isPausing)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) PauseGame();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape)) ResumeGame();
            else if (Input.GetKeyDown(KeyCode.UpArrow)) ChangeOption(-1);
            else if (Input.GetKeyDown(KeyCode.DownArrow)) ChangeOption(1);
            else if (Input.GetKeyDown(KeyCode.Space)) SelectOption();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        Global.SetPlayerControlTo(player, false);
        isPausing = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Global.SetPlayerControlTo(player, true);
        isPausing = false;
    }

    public void ExitGame()
    {
        PlayerStorage.SaveData();
        Debug.Log("Quit");
        Application.Quit();
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }

    void ChangeOption(int d)
    {
        if (currentOption == 0 && d == 1)
        {
            currentOption = 1;
            border.transform.localPosition = new Vector3(0, option1.transform.localPosition.y + 4, 0);

            GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.HOVER0_AUDIO_CODE);
        }
        else if (currentOption == 1 && d == -1)
        {
            currentOption = 0;
            border.transform.localPosition = new Vector3(0, option0.transform.localPosition.y + 4, 0);

            GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.HOVER0_AUDIO_CODE);
        }
    }

    void SelectOption()
    {
        GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.CLICK_AUDIO_CODE);

        if (currentOption == 0) ResumeGame();
        else if (currentOption == 1) ExitGame();

    }

}
