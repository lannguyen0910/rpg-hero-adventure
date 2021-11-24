using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShopController : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    int[] price = new int[4] { 0, 100, 250, 0};

    GameObject[] options;
    GameObject border;
    GameObject gold;

    int currentOption = 0;

    void Start()
    {
        options = new GameObject[2];
        for (int i = 0; i < 2; i++)
        {
            options[i] = transform.Find("Option" + i).gameObject;
        }
        border = transform.Find("SelectBorder").gameObject;
        gold = transform.Find("Gold").gameObject;

        ShowSkills();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) CloseShop();
        else if (Input.GetKeyDown(KeyCode.UpArrow)) ChangeOption(-1);
        else if (Input.GetKeyDown(KeyCode.DownArrow)) ChangeOption(1);
        else if (Input.GetKeyDown(KeyCode.Space)) SelectOption();
    }

    void CloseShop()
    {
        gameObject.SetActive(false);
        Global.SetPlayerControlTo(player, true);
    }

    void ChangeOption(int d)
    {
        if (currentOption + d >= 0 && currentOption + d < 2)
        {
            currentOption += d;
            border.transform.localPosition = new Vector3(0, options[currentOption].transform.localPosition.y + 15, 0);
            GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.HOVER1_AUDIO_CODE);
        }
    }

    void SelectOption()
    {
        if (currentOption == 0)
        {
            if (PlayerStorage.meleeSkill == 3) return;
            if (PlayerStorage.gold < price[PlayerStorage.meleeSkill]) return;
            PlayerStorage.gold -= price[PlayerStorage.meleeSkill];
            PlayerStorage.meleeSkill++;

            if (PlayerStorage.meleeSkill == 2) player.transform.Find("Weapon").Find("Melee").gameObject.GetComponent<WeaponMeleeGuardAction>().enabled = true;
            else if (PlayerStorage.meleeSkill == 3) player.transform.Find("Weapon").Find("Melee").gameObject.GetComponent<WeaponMeleeDashAction>().enabled = true;

            GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.BUY_AUDIO_CODE);
        }
        else if (currentOption == 1)
        {
            if (PlayerStorage.magicSkill == 3) return;
            if (PlayerStorage.gold < price[PlayerStorage.magicSkill]) return;
            PlayerStorage.gold -= price[PlayerStorage.magicSkill];
            PlayerStorage.magicSkill++;

            if (PlayerStorage.magicSkill == 2) player.transform.Find("Weapon").Find("Magic").gameObject.GetComponent<WeaponMagicExplodeAction>().enabled = true;
            else if (PlayerStorage.magicSkill == 3) player.transform.Find("Weapon").Find("Magic").gameObject.GetComponent<WeaponMagicIceAction>().enabled = true;

            GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.BUY_AUDIO_CODE);
        }

        ShowSkills();
    }

    void ShowSkills()
    {
        for (int i = 0; i < 2; i++)
        {
            int cur = i == 0 ? PlayerStorage.meleeSkill : PlayerStorage.magicSkill;
            for (int k = 0; k < 3; k++)
            {
                GameObject s = options[i].transform.Find("Skill" + k).gameObject;
                GameObject t = options[i].transform.Find("Text" + k).gameObject;

                if (cur > k)
                {
                    s.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1);
                    t.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 1, 1);
                }
            }
            options[i].transform.Find("Price").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = price[cur].ToString();
        }
        gold.GetComponent<TMPro.TextMeshProUGUI>().text = "You have " + PlayerStorage.gold + " gold";
    }
}
