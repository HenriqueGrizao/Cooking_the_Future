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

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,5);
    }
    void FixedUpdate()
    {
        Vector2 direcao = jogador.transform.position - transform.position;
        distanciaAteJogador = direcao.x * direcao.x + direcao.y * direcao.y;

        if (distanciaAteJogador <= AtacarQuando)
        {
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + direcao.normalized * Velocidade * Time.deltaTime);
        }
        else { ; }

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
