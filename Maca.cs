using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maca : MonoBehaviour
{
    public float Velocidade;
    public float AtacarQuando;
    public float CooldownDoDano;
    public float AtirarQuando;

    public float distanciaAteJogador;
    private GameObject jogador;
    private float cronometroDano;
    private VidaJogador vidaJogador;
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        cronometroDano = CooldownDoDano;
        vidaJogador = jogador.GetComponent<VidaJogador>();
    }
    void FixedUpdate()
    {
        Vector2 direcao = jogador.transform.position - transform.position;
        distanciaAteJogador = direcao.x * direcao.x + direcao.y * direcao.y;

        if (distanciaAteJogador <= AtirarQuando)
        {
            Debug.Log("atirar");
        } else if (distanciaAteJogador <= AtacarQuando)
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + direcao.normalized * Velocidade * Time.deltaTime);
        }

        cronometroDano += Time.deltaTime;
    }
   /* void OnCollisionStay2D(Collision2D objetoDeColisao)
    {
        if (objetoDeColisao.gameObject == jogador && cronometroDano >= CooldownDoDano)
        {

            vidaJogador.SofrerDano(1);
            cronometroDano = 0;
            if (cronometroDano >= CooldownDoDano)
            {
                vidaJogador.SofrerDano(1);
                cronometroDano = 0;
            }
        }
    }*/
}
