using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IUManeger : MonoBehaviour
{
    public Slider slider;
    public Text TextoMoeda;
    public string NomeFase;

    private StatusJogador Jogador_vida;
    public static IUManeger instance;

    private void Awake()
    {
        instance = this;
        Invoke("AutalizaBarraDeVida", 0.2f);
        Invoke("AutalizarMoedas", 0.2f);
    }

    void Start()
    {
        Jogador_vida = GameObject.FindWithTag("Player").GetComponent<StatusJogador>();
        slider.maxValue = Jogador_vida.vidaMaxima;
    }
    //Muda o valor do "slider", atualizabndo a barra de vida
    public void AutalizaBarraDeVida()
    {
        slider.value = GameManager.instance.VidaJogador;
    }
    //Pega as moedas do "GameManager" e converte para texto e atualiza na tela
    public void AutalizarMoedas() 
    {
        int quantMoeda = GameManager.instance.Coins;
        string quantMoedaText = "0000";
        if (quantMoeda < 10) { quantMoedaText = "000" + quantMoeda; } 
        else if (quantMoeda < 100) { quantMoedaText = "00" + quantMoeda; }
        else if(quantMoeda < 1000) { quantMoedaText = "0" + quantMoeda; }
        TextoMoeda.text = "Moeda: " + quantMoedaText;
    }
    //Reseta a fase
    public void Reset()
    {
        Debug.LogWarning("Inplementar chekpoint");
        Time.timeScale = 1;
        SceneManager.LoadScene(NomeFase);
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
