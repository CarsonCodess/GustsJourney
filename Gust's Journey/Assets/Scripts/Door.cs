using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite endSprite;
    [SerializeField] private Transform cow1;
    [SerializeField] private Transform cow2;
    private bool _done;
    
    private void Update()
    {
        if (GameManager.Instance.IsDragging && (Input.GetKey(KeyCode.F) || Input.GetMouseButton(1)))
        { 
            if (GameManager.Instance.WindDirection.x > 0 && !_done)
            {
                GetComponentInChildren<SpriteRenderer>().sprite = endSprite;
                cow1.DOMoveX(1.3f, 1.5f);
                cow2.DOMoveX(-1.3f, 1.5f);
                Invoke(nameof(NextLevel), 3f);
                _done = true;
            }
        }
    }
    
    private void NextLevel()
    {
        TransitionManager.Instance.StartTransition(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
