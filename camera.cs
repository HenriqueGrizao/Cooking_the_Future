using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public short limiteEsquerdaX;
    public short limiteCimaY;
    public short limiteDireitaX;
    public short limiteBaixoY;

    private GameObject jogador;
    private Vector3 posisao;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        z = transform.position.z;
        posisao.z = z;
        jogador = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    { if(jogador.transform.position.y < limiteCimaY && jogador.transform.position.y > limiteBaixoY) { posisao.y = jogador.transform.position.y; }
      if (jogador.transform.position.x < limiteDireitaX && jogador.transform.position.x > limiteEsquerdaX) { posisao.x = jogador.transform.position.x; }    
        transform.position = posisao;
    }
}
