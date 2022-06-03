using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJogador : MonoBehaviour
{
    public int vidaMaxima;
    public int vida;

    private Canvas Canvas;
    private jogador_melancia Jogador_Melancia;
    void Start()
    {
        vida = vidaMaxima;
        Canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        Jogador_Melancia = GameObject.FindWithTag("Player").GetComponent<jogador_melancia>();
    }
    public void SofrerDano(int Dano)
    {
        vida -= Dano;
        Canvas.AutalizaBarraDeVida();
        if (vida <= 0)
        {
            Jogador_Melancia.enabled = false;
            Time.timeScale = 0;
            Canvas.transform.GetChild(0).gameObject.SetActive(true);
        }
        Jogador_Melancia.TrocaCor();
    }
}