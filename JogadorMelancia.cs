using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JogadorMelancia : MonoBehaviour
{
    public float Velocidade;
    public float DestroiAtaqueApos;
    public float Cooldown;
    public Canvas Canvas;
    public float DuracaoAtaque;

    private float cronometroAposAtaque;
    private Animator animacao;
    private Collider2D colliderCapsula;
    private Collider2D colliderQuadrado;
    private float eixoX = 0;
    private float eixoY = 0;
    private SpriteRenderer spriteRenderer;
    private int direcaoClik;
    private void Start()
    {
        animacao = GetComponent<Animator>();
        colliderCapsula = GetComponent<CapsuleCollider2D>();
        colliderQuadrado = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
    }
    void Update()
    {
        movimenta();
        cronometroAposAtaque += Time.deltaTime;
    }
    private void movimenta() 
    {
        //detecta qual tecla foi presionada e muda o x, y, animação e a colisão
        if (Input.GetKey(KeyCode.W)) { 
            eixoY = 1;
            animacao.SetFloat("direcao_y", 1); animacao.SetFloat("direcao_x", 0);
            colliderCapsula.enabled = true;
            colliderQuadrado.enabled = false;
        } else
        if (Input.GetKey(KeyCode.S)) { 
            eixoY = -1; 
            animacao.SetFloat("direcao_y", -1); animacao.SetFloat("direcao_x", 0);
            colliderCapsula.enabled = true;
            colliderQuadrado.enabled = false;
        }
        else { eixoY = 0; }
        if (Input.GetKey(KeyCode.D)) { 
            eixoX = 1; 
            animacao.SetFloat("direcao_y", 0); animacao.SetFloat("direcao_x", 1);
            colliderCapsula.enabled = false;
            colliderQuadrado.enabled = true;
        }
        else
        if (Input.GetKey(KeyCode.A)) { 
            eixoX = -1; 
            animacao.SetFloat("direcao_y", 0); animacao.SetFloat("direcao_x", -1);
            colliderCapsula.enabled = false;
            colliderQuadrado.enabled = true;
        }
        else
        { eixoX = 0;}

        animacao.SetBool("Andando", (eixoX != 0 || eixoY != 0));
        //corige o bug de adar o dobro de veloidade na diagoal;
        if (eixoX != 0 && eixoY != 0) { eixoX *= 0.8f; eixoY *= 0.8f; }

        
        float posicaoAtualX = transform.position.x;
        float posicaoAtualY = transform.position.y;
        Vector2 direcao = new Vector2(eixoX * Velocidade * Time.deltaTime + posicaoAtualX, eixoY * Velocidade * Time.deltaTime + posicaoAtualY);
        GetComponent<Rigidbody2D>().MovePosition(direcao);
    }
    //É chamado pelo detectaClick, informa a direção do ataque e chama o Atacar.  
    public  void comesaSocar(int direcao) 
    {
        direcaoClik = direcao;
        Atacar();
    }
    //É quem faz com que o jogador volte para o modo ondee não esta atacando;
    public void desativaAtaque() {
        transform.GetChild(direcaoClik).gameObject.SetActive(false);
        spriteRenderer.enabled = true;
    }
    //Verifica o cronometro para evitar espamar ataque. Coloca o jogador no modo de ataque e chama o desativaAtaque apos um tempo
    public void Atacar() 
    {
        if (Cooldown <= cronometroAposAtaque) 
        {
            spriteRenderer.enabled = false;
            transform.GetChild(direcaoClik).gameObject.SetActive(true);
            Invoke("desativaAtaque", DuracaoAtaque);
            cronometroAposAtaque = 0;
        }
    }
} 