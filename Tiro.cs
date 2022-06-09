using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public int Velocidade;

    private GameObject jogador;
    private Vector2 direcao;
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        direcao = jogador.transform.position - transform.position;
      //  Destroy(this.gameObject, 3f);
        //distanciaAteJogador = direcao.x * direcao.x + direcao.y * direcao.y;
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + direcao.normalized * Velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VidaJogador>().SofrerDano(1);
            Destroy(this.gameObject);
        }
        else if (!(collision.CompareTag("EditorOnly")) && !(collision.CompareTag("Enemy")))
        {
            Destroy(this.gameObject);

        }
    }
}
