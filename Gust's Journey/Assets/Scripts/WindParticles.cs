using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WindParticles : MonoBehaviour
{
    private void Awake()
    {
        transform.DODynamicLookAt(Vector3.zero, 0.25f);
    }

    private void Update()
    {
        PositionParticle();
    }

    private void PositionParticle()
    {
        var newPosition = transform.position;
        var windDirection = GameManager.Instance.WindDirection;
        if (windDirection.x < 0) // Right
        {
            
        }
        else if (windDirection.x > 0) // Left
        {
            
        }

        if (windDirection.y < 0) // Up
        {
            
        }
        else if (windDirection.y > 0) // Down
        {
            
        }

        transform.DOMove(newPosition, 0.05f).SetEase(Ease.OutQuad);
        Vector3 windDirection3D = new Vector3(windDirection.x, windDirection.y, 0);
        float angle = Mathf.Atan2(windDirection3D.y, windDirection3D.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
