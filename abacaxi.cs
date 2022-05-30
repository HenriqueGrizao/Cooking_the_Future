using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abacaxi : MonoBehaviour
{
    public  float Velocidade;
    public float AtacarQuando;
    public float CooldownDoDano;

    private float distanciaAteJogador;
    private GameObject jogador;
    public float cronometroDano;
    private Animator animator;
    private VidaJogador vidaJogador;
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        cronometroDano = CooldownDoDano;
        animator = GetComponent<Animator>();
        vidaJogador = jogador.GetComponent<VidaJogador>();
    }
    void FixedUpdate()
    {
        Vector2 direcao = jogador.transform.position - transform.position;
        distanciaAteJogador = direcao.x*direcao.x + direcao.y*direcao.y;

        if (distanciaAteJogador <= AtacarQuando) 
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + direcao.normalized * Velocidade * Time.deltaTime);
            animator.SetBool("andando", true);
        }
        else { animator.SetBool("andando", false); }
        
        cronometroDano += Time.deltaTime;
    }
    void OnCollisionStay2D(Collision2D objetoDeColisao)
    {
        if (objetoDeColisao.gameObject == jogador && cronometroDano >= CooldownDoDano)
        {

            vidaJogador.SofrerDano(1);
            //Batida = distanciaAteJogador;
            cronometroDano = 0;
            bater();
        }
    }
    void bater() 
    {
            if (cronometroDano >= CooldownDoDano)
            {
            
                vidaJogador.SofrerDano(1);
                cronometroDano = 0;
            }
    }
}
