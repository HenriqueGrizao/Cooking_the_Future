﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    public int Vida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void levardanoInimigo(int dano) 
    {
        Vida = Vida - dano;
   //     Debug.Log("levou");
        if (Vida <= 0) 
        {
            Debug.Log("Moreeu");
            Destroy(this.gameObject);
        }
    }
}
