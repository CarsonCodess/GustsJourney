using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartCanvas : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
            transform.GetChild(0).gameObject.SetActive(scene.name != "End");
        };
        transform.GetChild(0).gameObject.SetActive(false);
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
