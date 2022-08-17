using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public short limiteEsquerdaX;
    public short limiteCimaY;
    public short limiteDireitaX;
    public short limiteBaixoY;

    private GameObject jogador;
    private Vector3 posisao;
    private float z;
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        // organiza o vetor z
        z = transform.position.z;
        posisao.z = z;
    }

    // move a camera apenas quando não se ultrapassou o limite. 
    void Update()
    { if(jogador.transform.position.y < limiteCimaY && jogador.transform.position.y > limiteBaixoY) 
        { posisao.y = jogador.transform.position.y; }
      if (jogador.transform.position.x < limiteDireitaX && jogador.transform.position.x > limiteEsquerdaX) 
        { posisao.x = jogador.transform.position.x; }
      transform.position = posisao;
    }
}
