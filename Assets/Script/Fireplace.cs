﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    private Collider2D Fir;
    // Start is called before the first frame update
    void Start()
    {
        Fir = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Destroy(this.gameObject);
            Player.HP--;
        }
    }
}
