using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    public int Vida;
    // Start is called before the first frame update
   public void levardanoInimigo(int dano) 
    {
        Vida = Vida - dano;
        if (Vida <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
