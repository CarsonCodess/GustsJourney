using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private RectTransform cursor;
    [SerializeField] private RectTransform titleText;
    [SerializeField] private float titleScreenMoveRange = 10f;
    [SerializeField] private float titleScreenMoveSpeed = 1f;
    [SerializeField] private float cursorIncrement = 100f;
    [SerializeField] private float cursorMax = 100f;
    [SerializeField] private int cursorMaxElements = 3;
    [SerializeField] private Toggle crtToggle;
    [SerializeField] private RectTransform titleScreen;

    private int _cursorIndex;

    public void OnEnable()
    {
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetMouseButtonUp(0))
        {
            if (_cursorIndex == 0)
            {
                crtToggle.OnSubmit(new BaseEventData(null));
                if (crtToggle.isOn)
                {
                    volume.profile.TryGet(typeof(FilmGrain), out FilmGrain filmGrain);
                    volume.profile.TryGet(typeof(PaniniProjection), out PaniniProjection paniniProjection);
                    filmGrain.intensity.value = 0.2f;
                    paniniProjection.distance.value = 1f;
                }
                else
                {
                    volume.profile.TryGet(typeof(FilmGrain), out FilmGrain filmGrain);
                    volume.profile.TryGet(typeof(PaniniProjection), out PaniniProjection paniniProjection);
                    filmGrain.intensity.value = 0f;
                    paniniProjection.distance.value = 0f;
                }
            }
            else if (_cursorIndex == 1)
            {
                titleScreen.gameObject.SetActive(true);
                titleScreen.DOAnchorPosY(0f, 1f).SetEase(Ease.OutCubic);
                ((RectTransform) transform).DOAnchorPosY(2000f, 0.75f).SetEase(Ease.OutCubic).OnComplete(() => gameObject.SetActive(false));
            }
        }
    }
}
