using System;
using Unity.Mathematics;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private RectTransform cursor;
    [SerializeField] private RectTransform titleText;
    [SerializeField] private float titleScreenMoveRange = 10f;
    [SerializeField] private float titleScreenMoveSpeed = 1f;

    private int _cursorIndex;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _cursorIndex = 0;
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) ||
            Input.GetKeyDown(KeyCode.RightAlt))
        {
            // Do something like pop up a menu
        }
    }
}
