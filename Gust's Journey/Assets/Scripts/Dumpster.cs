using System;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Object"))
        {
            col.gameObject.SetActive(false);
            // Increase Score or something idk
        }
    }
}
