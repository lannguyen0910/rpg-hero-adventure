using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorialController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Find("EndStageTransitionAnim").gameObject.SetActive(true);
            StartCoroutine(HomeLoad());
        }
    }

    IEnumerator HomeLoad()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("HomeScene");
    }
}
