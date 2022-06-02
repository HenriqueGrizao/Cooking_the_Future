using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laranja : MonoBehaviour
{
    public int Velocidade;
    public float AtacarQuando;
    public float CooldownDoDano;

    private float distanciaAteJogador;
    private GameObject jogador;
    public float cronometroDano;
    private VidaJogador vidaJogador;
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        cronometroDano = CooldownDoDano;
        vidaJogador = jogador.GetComponent<VidaJogador>();
    }

    
    void FixedUpdate()
    {

        Vector2 direcao = jogador.transform.position - transform.position;
        if(direcao.x <= 0) { transform.Rotate(0, 0, 5); } else { transform.Rotate(0, 0, -5); }

        distanciaAteJogador = direcao.x * direcao.x + direcao.y * direcao.y;

        if (distanciaAteJogador <= AtacarQuando)
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + direcao.normalized * Velocidade * Time.deltaTime);
        }
        cronometroDano += Time.deltaTime;
    }
    void OnCollisionStay2D(Collision2D objetoDeColisao)
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
    }
}