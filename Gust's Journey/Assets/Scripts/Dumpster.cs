using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dumpster : MonoBehaviour
{
    [SerializeField] private int items;
    private int _item;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Object"))
        {
            col.gameObject.SetActive(false);
            _item++;
            if(_item == items)
                Invoke(nameof(NextLevel), 1f);
        }
    }
    
    private void NextLevel()
    {
        TransitionManager.Instance.StartTransition(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
