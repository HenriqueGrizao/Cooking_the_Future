using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJogador : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jogador;
    public int vidaMaxima;
    public int vida;
    public Canvas Canvas;
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        vida = vidaMaxima;
        Canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
    }
    public void SofrerDano(int Dano)
    {
        vida -= Dano;
        Canvas.AutalizaBarraDeVida();
        if (vida <= 0)
        {
            jogador.GetComponent<jogador_melancia>().enabled = false;
            //this.enabled = false;
            Time.timeScale = 0;
            Canvas.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}