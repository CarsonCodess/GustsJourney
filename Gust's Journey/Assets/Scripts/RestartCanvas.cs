using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartCanvas : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += SceneLoad;
    }

    private void SceneLoad(Scene scene, LoadSceneMode mode)
    {
        if(!transform)
            return;
        GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
        transform.GetChild(0).gameObject.SetActive(scene.name != "End" && scene.name != "Menu");
    }

    private void Update()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
                TransitionManager.Instance.StartTransition(SceneManager.GetActiveScene().name);
        }
    }
}
