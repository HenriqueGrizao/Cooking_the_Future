using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusInimigo : MonoBehaviour
{
    public float vida;
    public int VidaMax;
    public int defesa;
    public int dano;
    public float CooldownDoDano;
    public GameObject BarraDeVida;
    public Color CorDano;
    public SpriteRenderer spriteRenderer;

    private float PorcentagenVida;
    private Vector3 scaleBarraVidaV;
    private Color CorPadrao;
    private GameObject jogador;
    private bool podeAtacar = true;
    public void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        //seta a cor padrão, vida e o tamanho da barra de vida
        vida = VidaMax;
        scaleBarraVidaV.y = 1;
        scaleBarraVidaV.z = 1;
        CorPadrao = spriteRenderer.color;
    }
    public void levardanoInimigo(int dano) 
    {
        vida = vida - (dano - defesa);
        PorcentagenVida = vida / VidaMax;
        if (vida <= 0) 
        {
            Destroy(this.gameObject);
        }
        else { 
            TrocaCor();
            //coloca na Scala a porcentagen da vida no lugar do x
            scaleBarraVidaV.x = PorcentagenVida;
            BarraDeVida.transform.GetChild(1).transform.localScale = scaleBarraVidaV;
        }
    }
    void voltaCor() { spriteRenderer.color = CorPadrao; }
    public void TrocaCor()
    {
        spriteRenderer.color = CorDano;
        Invoke("voltaCor", 0.15f);
    }
    //dá dano no jogador de forma melee
    public void darDano(Collision2D objetoDeColisao, StatusJogador statusjogador) 
    {
        if (objetoDeColisao.gameObject == jogador && podeAtacar)
        {
            StatusJogador statusJogador = statusjogador.GetComponent<StatusJogador>();
            //pega o dano no statusInimigo e da o dano no jogador
            statusJogador.SofrerDano(dano);
            podeAtacar = false;
            Invoke("podeAtacarDeNovo", CooldownDoDano);
        }
    } 
    //serve como cooldwn
    public void podeAtacarDeNovo() 
    {
        podeAtacar = true;
    }
}
