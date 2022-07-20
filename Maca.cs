using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maca : MonoBehaviour
{
    public float Velocidade;
    public float AtacarQuando;
    public float CooldownDoDano;
    public float AtirarQuando;
    public GameObject tiro;


    private float distanciaAteJogador;
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
            cronometroDano += Time.deltaTime;
            if (cronometroDano >= CooldownDoDano)
            { 
                Instantiate(tiro, transform.GetChild(1).transform);
                cronometroDano = 0;
            }

        } else if (distanciaAteJogador <= AtacarQuando)
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + direcao.normalized * Velocidade * Time.deltaTime);
        }
    }
}
