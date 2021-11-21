using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpriteController : MonoBehaviour
{
    GameObject player;
    WeaponHolder weaponHolder;

    GameObject[] sprites;

    void Start()
    {
        sprites = new GameObject[2];
        for (int i = 0; i < 2; i++)
            sprites[i] = transform.Find("Weapon" + i).Find("Sprite").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
            if (player != null) weaponHolder = player.GetComponent<WeaponHolder>();
            return;
        }

        int cur = weaponHolder.GetCurrentWeaponType();
        for (int i = 0; i < 2; i++)
        {
            sprites[i].GetComponent<UnityEngine.UI.Image>().sprite = 
                weaponHolder.GetWeapon((cur + i) % 2).gameObject.GetComponent<WeaponAnimation>().sprites[1];
        }
    }
}
