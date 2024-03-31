using System;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private RectTransform cursor;
    [SerializeField] private RectTransform titleText;
    [SerializeField] private float titleScreenMoveRange = 10f;
    [SerializeField] private float titleScreenMoveSpeed = 1f;
    [SerializeField] private string mainSceneName = "Tutorial1";
    [SerializeField] private RectTransform optionsMenu;

    private int _cursorIndex;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnEnable()
    {
        _cursorIndex = 0;
        cursor.anchoredPosition = new Vector2(_cursorIndex == 1 ? -250 : -175, 100 - (_cursorIndex - 0) * 100);
    }

    private void Update()
    {
        var yMove = titleScreenMoveRange * math.sin(Time.time * titleScreenMoveSpeed);
        titleText.anchoredPosition = new Vector2(0f, titleText.anchoredPosition.y + yMove);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _cursorIndex++;
            _cursorIndex = Mathf.Clamp(_cursorIndex, 0, 2);
            cursor.anchoredPosition = new Vector2(_cursorIndex == 1 ? -250 : -175, 100 - (_cursorIndex - 0) * 100);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _cursorIndex--;
            _cursorIndex = Mathf.Clamp(_cursorIndex, 0, 2);
            cursor.anchoredPosition = new Vector2(_cursorIndex == 1 ? -250 : -175, 100 - (_cursorIndex + 0) * 100);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_cursorIndex == 0)
                TransitionManager.Instance.StartTransition(mainSceneName);
            else if (_cursorIndex == 1)
            {
                optionsMenu.gameObject.SetActive(true);
                optionsMenu.DOAnchorPosY(0f, 1f).SetEase(Ease.OutCubic);
                ((RectTransform) transform).DOAnchorPosY(-2000f, 0.75f).SetEase(Ease.OutCubic).OnComplete(() => gameObject.SetActive(false));
            }
            else if(_cursorIndex == 2)
                TransitionManager.Instance.StartTransitionQuit();
        }
    }
}
