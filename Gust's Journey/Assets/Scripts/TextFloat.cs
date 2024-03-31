using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class TextFloat : MonoBehaviour
{

    [SerializeField] private float titleScreenMoveRange = .05f;
    [SerializeField] private float titleScreenMoveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var yMove = titleScreenMoveRange * math.sin(Time.time * titleScreenMoveSpeed);
        ((RectTransform)transform).anchoredPosition = new Vector2(0f, ((RectTransform)transform).anchoredPosition.y + yMove);   
    }
}
