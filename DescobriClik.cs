using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescobriClik : MonoBehaviour
{
    // Start is called before the first frame update
    public int direcao;
    public jogador_melancia jogador;
    private void Start()
    {
        jogador = GameObject.FindWithTag("Player").GetComponent<jogador_melancia>();
    }
    private void Update()
    {
        transform.position = jogador.transform.position;
    }
    private void OnMouseDown()
    {
        jogador.comesaSocar(direcao);
    }
}
