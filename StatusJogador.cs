using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusJogador : MonoBehaviour
{
    public int vidaMaxima;
    public int vida;
    public int Defesa;
    public int Dano;
    public SpriteRenderer spriteRenderer;
    public Color CorDano;
    
    private Color CorPadrao;
    private Canvas Canvas;
    private JogadorMelancia Jogador_Melancia;
    void Start()
    {
        vida = vidaMaxima;
        Canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        Jogador_Melancia = GameObject.FindWithTag("Player").GetComponent<JogadorMelancia>();
        CorPadrao = spriteRenderer.color;
    }
    public void SofrerDano(int Dano)
    {
        vida -= (Dano - Defesa);
        Canvas.AutalizaBarraDeVida();
        if (vida <= 0)
        {
            Jogador_Melancia.enabled = false;
            Time.timeScale = 0;
            Canvas.transform.GetChild(0).gameObject.SetActive(true);
        }
        TrocaCor();
    }
    //Volta para a coloração normal
    private void voltaCor() 
    { spriteRenderer.color = CorPadrao; }
    //troca a cor e chama o voltarCor apos um tempo
    private void TrocaCor()
    {
        spriteRenderer.color = CorDano;
        Invoke("voltaCor", 0.15f);
    }
    public void Curar(int Cura) 
    {
        vida += Cura;
        if(vida >= vidaMaxima) 
        {
            vida = vidaMaxima;
        }
    }
}