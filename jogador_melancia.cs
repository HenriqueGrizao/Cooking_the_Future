using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogador_melancia : MonoBehaviour
{
    public float Velocidade;
    public float DestroiAtaqueApos;
    public float Cooldown;
    public Canvas Canvas;
    public int Dano;
    public Color CorDano;

    private Color CorPadrao;
    private bool estaAtacando;
    private float cronometroAposAtaque;
    private Animator animacao;
    private Collider2D capsula;
    private Collider2D quadrado;
    private short eixoX = 0;
    private short eixoY = 0;
    private float cronometroDestroiAtaque;
    private SpriteRenderer spriteRenderer;
    private bool ComesaAtaque;
    private int direcaoClik;

    private void Start()
    {
        animacao = GetComponent<Animator>();
        capsula = GetComponent<CapsuleCollider2D>();
        quadrado = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        CorPadrao = spriteRenderer.color;
    }
    void Update()
    {
        movimenta();
        socar();
    }
    void movimenta() 
    {

        if (Input.GetKey(KeyCode.W)) { 
            eixoY = 1;
            animacao.SetFloat("direcao_y", 1); animacao.SetFloat("direcao_x", 0);
            capsula.enabled = true;
            quadrado.enabled = false;
        } else
        if (Input.GetKey(KeyCode.S)) { 
            eixoY = -1; 
            animacao.SetFloat("direcao_y", -1); animacao.SetFloat("direcao_x", 0);
            capsula.enabled = true;
            quadrado.enabled = false;
        }
        else { eixoY = 0; }
        if (Input.GetKey(KeyCode.D)) { 
            eixoX = 1; 
            animacao.SetFloat("direcao_y", 0); animacao.SetFloat("direcao_x", 1);
            capsula.enabled = false;
            quadrado.enabled = true;
        }
        else
        if (Input.GetKey(KeyCode.A)) { 
            eixoX = -1; 
            animacao.SetFloat("direcao_y", 0); animacao.SetFloat("direcao_x", -1);
            capsula.enabled = false;
            quadrado.enabled = true;
        }
        else
        { eixoX = 0;}
        animacao.SetBool("Andando", (eixoX != 0 || eixoY != 0));

        float posicaoAtualX = transform.position.x;
        float posicaoAtualY = transform.position.y;

        Vector2 direcao = new Vector2(eixoX * Velocidade * Time.deltaTime + posicaoAtualX, eixoY * Velocidade * Time.deltaTime + posicaoAtualY);
        GetComponent<Rigidbody2D>().MovePosition(direcao);

    }
    public  void comesaSocar(int direcao) 
    {
        ComesaAtaque = true;
        direcaoClik = direcao;
    }

    public void socar() 
    {
        cronometroAposAtaque += Time.deltaTime;
        if (estaAtacando == true)
        {
            cronometroDestroiAtaque += Time.deltaTime;
        } 
        if (ComesaAtaque && Cooldown <= cronometroAposAtaque)
        {
            spriteRenderer.enabled = false;
            transform.GetChild(direcaoClik).gameObject.SetActive(true);
            estaAtacando = true;
            cronometroAposAtaque = 0;
        }
        if (cronometroDestroiAtaque >= DestroiAtaqueApos) 
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            spriteRenderer.enabled = true;
            estaAtacando = false;
            cronometroDestroiAtaque = 0;
            ComesaAtaque = false;
        }
    }
    void voltaCor() { spriteRenderer.color = CorPadrao; } 
    public void TrocaCor()
    {
        spriteRenderer.color = CorDano;
        Invoke("voltaCor", 0.1f);


    }
   
} 