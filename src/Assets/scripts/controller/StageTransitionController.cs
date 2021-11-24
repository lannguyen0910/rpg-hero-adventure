using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTransitionController : MonoBehaviour
{
    GameObject player;
    string destination;
    float delay = 0f;
    bool already = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        delay += Time.deltaTime;

        if (player != null)
        {
            if (!already && Global.IsGreaterEqual(delay, 0.5f))
            {
                already = true;
                if (destination != "Stage 1") PlayerStorage.gold += (destination[6] - '0' - 1) * 20;
                StartCoroutine(NextStageLoad());
            }
        }
        else
        {
            if (Global.IsGreaterEqual(delay, 1f))
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void SetParameter(string scene, GameObject gameObject)
    {
        destination = scene;
        player = gameObject;
    }

    IEnumerator NextStageLoad()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(destination, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(destination));

        // Move the player to the new stage
        GameObject newPlayer = Instantiate(player);
        newPlayer.name = "Player";
        newPlayer.transform.position = new Vector3(Global.DEFAULT_PLAYER_POS_X, Global.DEFAULT_PLAYER_POS_Y, 0);
        // Change weapon if necessary
        newPlayer.GetComponent<WeaponHolder>().SetCurrentWeaponType(player.GetComponent<WeaponHolder>().GetCurrentWeaponType());
        // Turn on input again
        Global.SetPlayerControlTo(newPlayer, true);

        // Unload this stage
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
