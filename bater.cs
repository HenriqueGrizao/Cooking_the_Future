using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bater : MonoBehaviour
{
    //private jogador_melancia jogador;
    public int dano;       

    private void Start()
    {
      //  jogador = GameObject.FindWithTag("Player").GetComponent<jogador_melancia>();
        dano = GameObject.FindWithTag("Player").GetComponent<jogador_melancia>().Dano;
    }
    void OnTriggerEnter2D(Collider2D objetoDeColisao)
    {
        if (objetoDeColisao.CompareTag("Enemy")) 
        {
            objetoDeColisao.GetComponent<VidaInimigo>().levardanoInimigo(dano);
        }
       
    }
    private void OnMouseDown()
    {
        
    }
}
