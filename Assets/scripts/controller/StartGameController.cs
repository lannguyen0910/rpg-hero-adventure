using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    GameObject[] options;
    GameObject border;
    GameObject menu;
    UnityEngine.UI.Slider slider;

    string path;
    bool firsttime = true;
    float volume = 1f;

    int currentOption = 0;

    void Start()
    {
        path = Application.persistentDataPath + "/firsttime.txt";
        try
        {
            StreamReader reader = new StreamReader(path);
            firsttime = false;
            volume = float.Parse(reader.ReadLine());
            reader.Close();
        }
        catch (Exception)
        {
            StreamWriter writer = new StreamWriter(path, false);
            writer.WriteLine(1);
            writer.Close();
        }
        
        options = new GameObject[3];
        for (int i = 0; i < 3; i++)
            options[i] = transform.Find("Option" + i).gameObject;
        border = transform.Find("SelectBorder").gameObject;
        menu = transform.Find("Settings Menu").gameObject;
        slider = menu.transform.Find("Slider").gameObject.GetComponent<UnityEngine.UI.Slider>();
        slider.value = volume;

        if (!firsttime)
        {
            options[0].SetActive(false);
            options[0] = transform.Find("Option" + 3).gameObject;
            options[0].SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) ChangeOption(-1);
        else if (Input.GetKeyDown(KeyCode.DownArrow)) ChangeOption(1);
        else if (Input.GetKeyDown(KeyCode.Space)) SelectOption();
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) ChangeVolume(-0.1f);
        else if (Input.GetKeyDown(KeyCode.RightArrow)) ChangeVolume(0.1f);
    }

    public void NewGame()
    {
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(slider.value);
        writer.Close();

        // Show tutorial here
        transform.Find("EndStageTransitionAnim").gameObject.SetActive(true);
        StartCoroutine(HomeLoad("TutorialScene"));
    }

    public void LoadGame()
    {
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(slider.value);
        writer.Close();

        // Load all data here
        transform.Find("EndStageTransitionAnim").gameObject.SetActive(true);
        StartCoroutine(HomeLoad("HomeScene"));
    }

    IEnumerator HomeLoad(string scene)
    {
        yield return new WaitForSeconds(0.45f);
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(slider.value);
        writer.Close();

        Debug.Log("Quit");
        Application.Quit();
    }

    void ChangeOption(int d)
    {
        if (menu.activeInHierarchy) return;
        if (currentOption + d >= 0 && currentOption + d < 3)
        {
            currentOption += d;
            border.transform.localPosition = new Vector3(0, options[currentOption].transform.localPosition.y, 0);
        }
    }

    void SelectOption()
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            return;
        }
        if (currentOption == 0 && firsttime) NewGame();
        if (currentOption == 0 && !firsttime) LoadGame();
        else if (currentOption == 1) transform.Find("Settings Menu").gameObject.SetActive(true);
        else if (currentOption == 2) QuitGame();
    }

    void ChangeVolume(float d)
    {
        if (!menu.activeInHierarchy) return;
        slider.value += d;
    }
}
