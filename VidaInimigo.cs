using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    public float vida;
    public int VidaMax;
    public GameObject BarraDeVida;

    private float PorcentagenVida;
    private Vector3 tamanhoDaBarra;
    public void Start()
    {
        vida = VidaMax;
        tamanhoDaBarra.y = 1;
        tamanhoDaBarra.z = 1;
    }
    public void levardanoInimigo(int dano) 
    {
        vida = vida - dano;
        PorcentagenVida = vida / VidaMax;
        if (vida <= 0) 
        {
            Destroy(this.gameObject);
        }
        tamanhoDaBarra.x = PorcentagenVida;
        BarraDeVida.transform.GetChild(1).transform.localScale = tamanhoDaBarra;
    }
}
