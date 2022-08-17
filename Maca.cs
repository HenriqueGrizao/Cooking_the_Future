using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maca : MonoBehaviour
{
    public float Velocidade;
    public float DistanciaDePercepcao;
    public float CooldownDoDano;
    public float AtirarQuando;
    public GameObject tiro;

    private bool podeAtacar = true;
    private float distanciaAteJogador;
    private GameObject jogador;
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
    }
    void FixedUpdate()
    {
        Vector2 direcao = jogador.transform.position - transform.position;
        distanciaAteJogador = Mathf.Sqrt(direcao.x * direcao.x + direcao.y * direcao.y);//teorema de pitagoras
        //atira no jogador a partir de um certa distancia
        if (distanciaAteJogador <= AtirarQuando)
        {
            if (podeAtacar)
            {
                Instantiate(tiro, transform.GetChild(1).transform);
                podeAtacar = false;
                Invoke("podeAtacarDeNovo", CooldownDoDano);
            }
        } else if (distanciaAteJogador <= DistanciaDePercepcao)//persegui o jogador a partir de um certa distancia
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + direcao.normalized * Velocidade * Time.deltaTime);
        }
    }
    //serve como cooldwn
    public void podeAtacarDeNovo()
    {
        podeAtacar = true;
    }
}
