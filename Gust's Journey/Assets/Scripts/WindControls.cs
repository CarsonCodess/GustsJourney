using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class WindControls : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float vertWind;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        Move();
    }

    private void Move(){
        
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Random.Range((float)-1, (float)4);
        if(horiz != 0){
            rb.velocity = new UnityEngine.Vector2(horiz*speed*Time.deltaTime, vert*vertWind*Time.deltaTime);
        }
        else{
            rb.velocity = new UnityEngine.Vector2(Random.Range((float)-130, (float)120)*Time.deltaTime, Random.Range((float)-.2, (float)0.05)*vertWind*Time.deltaTime);
        }

    }
}