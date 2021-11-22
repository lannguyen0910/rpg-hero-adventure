using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    WeaponHolder weaponHolder;

    int[] price = new int[6] { 0, 50, 100, 200, 500, 0 };

    GameObject[] sprites;
    GameObject[] priceTexts;
    GameObject border;
    GameObject gold;

    int currentOption = 0;

    void Start()
    {
        weaponHolder = player.GetComponent<WeaponHolder>();
        sprites = new GameObject[2];
        priceTexts = new GameObject[2];
        for (int i = 0; i < 2; i++)
        {
            sprites[i] = transform.Find("Weapon" + i).Find("Sprite").gameObject;
            priceTexts[i] = transform.Find("Weapon" + i).Find("Price").gameObject;
        }
        border = transform.Find("SelectBorder").gameObject;
        gold = transform.Find("Gold").gameObject;

        ShowWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) CloseShop();
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) ChangeOption(-1);
        else if (Input.GetKeyDown(KeyCode.RightArrow)) ChangeOption(1);
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
            border.transform.localPosition = new Vector3(sprites[currentOption].transform.parent.localPosition.x, 0, 0);
            GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.HOVER1_AUDIO_CODE);
        }
    }

    void SelectOption()
    {
        if (currentOption == 0)
        {
            if (PlayerStorage.melee == 5) return;
            if (PlayerStorage.gold < price[PlayerStorage.melee]) return;
            PlayerStorage.gold -= price[PlayerStorage.melee];
            PlayerStorage.melee++;

            // Destroy old weapon
            Destroy(player.transform.Find("Weapon").Find("Melee").gameObject);

            // Upgrade weapon
            GameObject meleePrefab = Resources.Load("prefabs/weapon/Melee" + PlayerStorage.melee) as GameObject;
            GameObject melee = Instantiate(meleePrefab, player.transform.Find("Weapon"));
            melee.name = "Melee";
            if (PlayerStorage.meleeSkill > 0) melee.GetComponent<WeaponMeleeAttackAction>().enabled = true;
            if (PlayerStorage.meleeSkill > 1) melee.GetComponent<WeaponMeleeGuardAction>().enabled = true;
            if (PlayerStorage.meleeSkill > 2) melee.GetComponent<WeaponMeleeDashAction>().enabled = true;
            player.GetComponent<PlayerAnimation>().meleeWeapon = melee;
            player.GetComponent<WeaponHolder>().weaponObjects[0] = melee;
            player.GetComponent<PlayerAnimation>().Reset();
            player.GetComponent<WeaponHolder>().Reset();

            GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.BUY_AUDIO_CODE);
        }
        else if (currentOption == 1)
        {
            if (PlayerStorage.magic == 5) return;
            if (PlayerStorage.gold < price[PlayerStorage.magic]) return;
            PlayerStorage.gold -= price[PlayerStorage.magic];
            PlayerStorage.magic++;

            // Destroy old weapon
            Destroy(player.transform.Find("Weapon").Find("Magic").gameObject);

            // Upgrade weapon
            GameObject magicPrefab = Resources.Load("prefabs/weapon/Magic" + PlayerStorage.magic) as GameObject;
            GameObject magic = Instantiate(magicPrefab, player.transform.Find("Weapon"));
            magic.name = "Magic";
            if (PlayerStorage.magicSkill > 0) magic.GetComponent<WeaponMagicFireAction>().enabled = true;
            if (PlayerStorage.magicSkill > 1) magic.GetComponent<WeaponMagicExplodeAction>().enabled = true;
            if (PlayerStorage.magicSkill > 2) magic.GetComponent<WeaponMagicIceAction>().enabled = true;
            player.GetComponent<PlayerAnimation>().magicWeapon = magic;
            player.GetComponent<WeaponHolder>().weaponObjects[1] = magic;
            player.GetComponent<PlayerAnimation>().Reset();
            player.GetComponent<WeaponHolder>().Reset();

            GameObject.Find("AudioManager").gameObject.GetComponent<AudioManager>().PlayAudio(Global.BUY_AUDIO_CODE);
        }

        ShowWeapons();
    }

    void ShowWeapons()
    {
        for (int i = 0; i < 2; i++)
        {
            sprites[i].GetComponent<UnityEngine.UI.Image>().sprite =
                weaponHolder.GetWeapon(i).gameObject.GetComponent<WeaponAnimation>().sprites[0];
        }
        priceTexts[0].GetComponent<TMPro.TextMeshProUGUI>().text = price[PlayerStorage.melee].ToString();
        priceTexts[1].GetComponent<TMPro.TextMeshProUGUI>().text = price[PlayerStorage.magic].ToString();
        gold.GetComponent<TMPro.TextMeshProUGUI>().text = "You have " + PlayerStorage.gold + " gold";
    }
}
