using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    public Slider slider;
    public string NomeFase;
    private VidaJogador Jogador_vida;

    void Start()
    {
        Jogador_vida = GameObject.FindWithTag("Player").GetComponent<VidaJogador>();
        slider.maxValue = Jogador_vida.vidaMaxima;
        slider.value = slider.maxValue;
    }

    public void AutalizaBarraDeVida()
    {
        slider.value = Jogador_vida.vida;
    }
    public void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NomeFase);
    }
}
