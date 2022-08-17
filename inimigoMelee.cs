using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMelee : MonoBehaviour
{
    public float Velocidade;
    public float DistanciaDePercepcao;

    private float distanciaAteJogador;
    private GameObject jogador;
    public Animator animator;
    private StatusJogador statusJogador;
    private StatusInimigo statusInimigo;
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        statusJogador = jogador.GetComponent<StatusJogador>();
        statusInimigo = GetComponent<StatusInimigo>();
    }
    void FixedUpdate()
    {
        Vector2 direcao = jogador.transform.position - transform.position;
        distanciaAteJogador = Mathf.Sqrt(direcao.x * direcao.x + direcao.y * direcao.y);//teorema de pitagoras
        //anda até o jogador quando ele fica a uma certa distancia. Além de colocar a animação correta.
        if (distanciaAteJogador <= DistanciaDePercepcao)
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + direcao.normalized * Velocidade * Time.deltaTime);
            animator.SetBool("andando", true);
        }
        else { animator.SetBool("andando", false); }
    }
    void OnCollisionStay2D(Collision2D objetoDeColisao)
    {
        statusInimigo.darDano(objetoDeColisao, statusJogador);
    }
}