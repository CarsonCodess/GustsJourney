using Unity.Mathematics;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private RectTransform cursor;
    [SerializeField] private RectTransform titleText;
    [SerializeField] private float titleScreenMoveRange = 10f;
    [SerializeField] private float titleScreenMoveSpeed = 1f;
    [SerializeField] private float cursorIncrement = 100f;
    [SerializeField] private float cursorMax = 100f;
    [SerializeField] private int cursorMaxElements = 3;

    private int _cursorIndex;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _cursorIndex = 0;
        cursor.anchoredPosition = new Vector2(_cursorIndex == 0 ? -250 : -175, cursorMax - _cursorIndex * cursorIncrement);
    }

    private void Update()
    {
        var yMove = titleScreenMoveRange * math.sin(Time.time * titleScreenMoveSpeed);
        titleText.anchoredPosition = new Vector2(0f, titleText.anchoredPosition.y + yMove);
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _cursorIndex++;
            _cursorIndex = Mathf.Clamp(_cursorIndex, 0, cursorMaxElements - 1);
            cursor.anchoredPosition = new Vector2(_cursorIndex == 0 ? -250 : -175, cursorMax - _cursorIndex * cursorIncrement);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _cursorIndex--;
            _cursorIndex = Mathf.Clamp(_cursorIndex, 0, cursorMaxElements - 1);
            cursor.anchoredPosition = new Vector2(_cursorIndex == 0 ? -250 : -175, cursorMax - _cursorIndex * cursorIncrement);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) ||
            Input.GetKeyDown(KeyCode.RightAlt))
        {
            // Do something like pop up a menu
        }
    }
}