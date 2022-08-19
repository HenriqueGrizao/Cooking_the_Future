using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     public static GameManager instance;

    int coins = 0;
    int vidaJogador = 0;
    private SaveGameData savedGame;

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

    public void SaveGame() 
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Path.Combine(Application.streamingAssetsPath, "savaGameData.dat"));

        SaveGameData save = new SaveGameData();
        save.Coins = coins;
        save.Vida = vidaJogador;
        bf.Serialize(file, save);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Path.Combine(Application.streamingAssetsPath, "savaGameData.dat"))) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Path.Combine(Application.streamingAssetsPath, "savaGameData.dat"), FileMode.Open);

            SaveGameData save = (SaveGameData) bf.Deserialize(file);

            savedGame = save;

            file.Close();

            coins = save.Coins;
            vidaJogador = save.Vida;
        }
    }

    private void OnApplicationQuit()
    {  
      SaveGame();
    }

    public void NewGame() 
    {
        SceneManager.LoadScene("floresta-1");
    }
    public void LoadGame() 
    {
        Load();
        if (savedGame != null )
        {
        SceneManager.LoadScene("floresta-1");
        }

    }
}

  [Serializable]
class SaveGameData 
{
    public int Vida;
    public int Coins;
}