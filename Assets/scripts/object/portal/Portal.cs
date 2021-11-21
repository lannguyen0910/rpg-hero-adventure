using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string destination;

    [SerializeField]
    GameObject player;

    bool ready = false;

    void Update()
    {
        if (!ready) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Turn off input
            player.GetComponent<PlayerMovementController>().enabled = false;
            player.GetComponent<PlayerMeleeWeaponController>().enabled = false;
            player.GetComponent<PlayerMagicWeaponController>().enabled = false;

            // Start transition animation

            // Load stage
            StartCoroutine(NextStageLoad());
        }
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
        // Turn on input again
        newPlayer.GetComponent<PlayerMovementController>().enabled = true;
        newPlayer.GetComponent<PlayerMeleeWeaponController>().enabled = true;
        newPlayer.GetComponent<PlayerMagicWeaponController>().enabled = true;

        // Unload this stage
        SceneManager.UnloadSceneAsync(currentScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.gameObject == player)
        {
            ready = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.gameObject == player)
        {
            ready = false;
        }
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
