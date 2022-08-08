using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportar : MonoBehaviour
{
    public string NomeProximaFase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(NomeProximaFase);
    }
}
