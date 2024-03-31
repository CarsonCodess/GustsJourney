using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Object"))
        {
            Destroy(col.gameObject);
            Invoke(nameof(Reset), 1f);
        }
    }

    private void Reset()
    {
        TransitionManager.Instance.StartTransition(SceneManager.GetActiveScene().buildIndex);
    }
}
