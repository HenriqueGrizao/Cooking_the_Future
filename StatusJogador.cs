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
    private JogadorMelancia Jogador_Melancia;
    void Start()
    {
        vida = GameManager.instance.VidaJogador;
        if (vida <= 0)//Verifica de já tem a vida salva no GameManager
        {
            vida = vidaMaxima;
            GameManager.instance.VidaJogador = vida;
        }
        Jogador_Melancia = GameObject.FindWithTag("Player").GetComponent<JogadorMelancia>();
        CorPadrao = spriteRenderer.color;
    }
    public void SofrerDano(int Dano)
    {
        vida -= (Dano - Defesa);
        GameManager.instance.VidaJogador = vida;
        IUManeger.instance.AutalizaBarraDeVida();
        if (vida <= 0)
        {
            Time.timeScale = 0;
            IUManeger.instance.transform.GetChild(0).gameObject.SetActive(true);
        }
        TrocaCor();
    }
    //Volta para a coloração normal, chamado pelo Invoke
    private void voltaCor() 
    { spriteRenderer.color = CorPadrao; }
    //Troca a cor e chama o voltarCor apos um tempo
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
        GameManager.instance.VidaJogador = vida;
    }
}