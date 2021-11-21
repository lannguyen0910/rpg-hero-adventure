using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMenuController : MonoBehaviour
{
    GameObject player;

    List<Buff> buffs;
    GameObject[] options = new GameObject[2];
    GameObject border;

    int currentOption = 0;

    void Start()
    {
        // Turn off pause
        transform.parent.gameObject.GetComponent<PauseController>().enabled = false;
        // Find player and stuff
        player = GameObject.Find("Player");
        for (int i = 0; i < 2; i++)
            options[i] = transform.Find("Option" + i).gameObject;
        border = transform.Find("SelectBorder").gameObject;
        // Generate buffs and show on screen
        buffs = BuffManager.GetRandomBuffs();
        for (int i = 0; i < 2; i++)
            options[i].transform.Find("Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = buffs[i].GetDescription();
        // Za warudo
        Global.SetPlayerControlTo(player, false);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) ChangeOption(-1);
        else if (Input.GetKeyDown(KeyCode.DownArrow)) ChangeOption(1);
        else if (Input.GetKeyDown(KeyCode.Space)) SelectOption();
    }

    void ChangeOption(int d)
    {
        if (currentOption + d >= 0 && currentOption + d < 2)
        {
            currentOption += d;
            border.transform.localPosition = new Vector3(0, options[currentOption].transform.localPosition.y + 4, 0);
        }
    }

    void SelectOption()
    {
        BuffManager.ChooseBuff(currentOption);
        buffs[currentOption].Process(player);

        // Za warudo in reverse
        transform.parent.gameObject.GetComponent<PauseController>().enabled = true;
        Global.SetPlayerControlTo(player, true);
        Time.timeScale = 1f;

        gameObject.SetActive(false);
    }
}
