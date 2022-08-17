using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    public Slider slider;
    public string NomeFase;
    private StatusJogador Jogador_vida;

    void Start()
    {
        Jogador_vida = GameObject.FindWithTag("Player").GetComponent<StatusJogador>();
        slider.maxValue = Jogador_vida.vidaMaxima;
        slider.value = slider.maxValue;
    }
    // muda o valor do slider
    public void AutalizaBarraDeVida()
    {
        slider.value = Jogador_vida.vida;
    }
    //reseta a fase
    public void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NomeFase);
    }
}
