using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     public static GameManager instance;

    int coins = 0;
    int vidaJogador = 5;

    public  int Coins 
    { 
        get
        { 
            return coins;
        }
        set
        { 
            coins = value;
            IUManeger.instance.AutalizarMoedas();
        }
    }
    public int VidaJogador
    {
        get
        {
            return vidaJogador;
        }
        set
        {
            vidaJogador = value;
        }
    }    
    //Impede a sua destruição ao mudar de fase
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {//Se destroi quando tem já tem um GameManager na cena
            Destroy(gameObject);
        }
    }
}
 