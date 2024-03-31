using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private bool _isDragging;

    private void Update()
    {
        var mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            GameManager.Instance.StopAutoWindChange();
        }
        else if (Input.GetMouseButton(0) && _isDragging)
        {
            var windDirection = (mouseWorldPosition - Vector3.zero).normalized;
            DOVirtual.Vector2(GameManager.Instance.WindDirection, windDirection, 0.4f, value =>
            {
                GameManager.Instance.WindDirection = value;
            });
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
            GameManager.Instance.StartAutoWindChange();
        }

        PositionParticle();
    }

    private void PositionParticle()
    {
        var newPosition = transform.position;
        var windDirection = GameManager.Instance.WindDirection;
        transform.DOMove(newPosition, 0.05f).SetEase(Ease.OutQuad);
        Vector3 windDirection3D = new Vector3(windDirection.x, windDirection.y, 0);
        float angle = Mathf.Atan2(windDirection3D.y, windDirection3D.x) * Mathf.Rad2Deg;
        transform.DORotate(new Vector3(0, 0, angle - 90), 0.25f);
    }
}
