using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laranja : MonoBehaviour
{
    public int Velocidade;
    public float DistanciaDePercepcao;
    public GameObject Sprite;

    private float distanciaAteJogador;
    private GameObject jogador;
    private StatusJogador statusJogador;
    private StatusInimigo statusInimigo;
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        statusJogador = jogador.GetComponent<StatusJogador>();
        statusInimigo = GetComponent<StatusInimigo>();
    }
    void FixedUpdate()
    {
        Vector2 direcao = jogador.transform.position - transform.position;
        //saber em que direcao vai girar com base no x
        if(direcao.x <= 0) { Sprite.transform.Rotate(0, 0, 5); } else { Sprite.transform.Rotate(0, 0, -5); }

        distanciaAteJogador = Mathf.Sqrt(direcao.x * direcao.x + direcao.y * direcao.y);//teorema de pitagoras
        //anda até o jogador quando ele fica a uma certa distancia
        if (distanciaAteJogador <= DistanciaDePercepcao)
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + direcao.normalized * Velocidade * Time.deltaTime);
        }
    }
    void OnCollisionStay2D(Collision2D objetoDeColisao)
    {
        statusInimigo.darDano(objetoDeColisao, statusJogador);
    }
}