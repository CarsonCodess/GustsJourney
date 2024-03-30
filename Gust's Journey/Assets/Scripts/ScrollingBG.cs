using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField] private Transform layer1;
    [SerializeField] private Transform layer2;
    [SerializeField] private float scrollSpeed;

    private float _layerWidth;

    private void Awake()
    {
        _layerWidth = layer1.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        layer1.position = new Vector2(layer1.position.x - scrollSpeed * Time.deltaTime, layer1.position.y);
        layer2.position = new Vector2(layer2.position.x - scrollSpeed * Time.deltaTime, layer2.position.y);
        if(layer1.position.x <= -_layerWidth)
            layer1.position = new Vector2(layer2.position.x + _layerWidth, layer1.position.y);
        else if(layer2.position.x <= -_layerWidth)
            layer2.position = new Vector2(layer1.position.x + _layerWidth, layer2.position.y);
    }
}
