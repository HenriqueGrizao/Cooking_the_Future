using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescobriClik : MonoBehaviour
{
    public int direcao;
    public JogadorMelancia jogador;
    private void Start()
    {
        jogador = GameObject.FindWithTag("Player").GetComponent<JogadorMelancia>();
    }
    private void Update()
    {// acompanha o movimento do jogador
        transform.position = jogador.transform.position;
    }
    private void OnMouseDown()
    {//informa a direção
        jogador.comesaSocar(direcao);
    }
}
