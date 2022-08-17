using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bater : MonoBehaviour
{//Fica no ataque para detectar com que ele colidiu e dar o dano
    public int dano;

    private void Start()
    {//o valor do dano esta sendo pego da variavel do jogador
        dano = GameObject.FindWithTag("Player").GetComponent<StatusJogador>().Dano;
    }
    void OnTriggerEnter2D(Collider2D objetoDeColisao)
    {
        if (objetoDeColisao.CompareTag("Enemy")) 
        {
            objetoDeColisao.GetComponent<StatusInimigo>().levardanoInimigo(dano);
        }
       
    }
}
