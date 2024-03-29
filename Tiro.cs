using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public int Velocidade;
    public int dano;
    public GameObject particula;
    public SpriteRenderer spriteRenderer;

    private GameObject jogador;
    private Vector2 direcao;
    private float x;
    private float y;
    private float p;
    private short quadrante;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        jogador = GameObject.FindWithTag("Player");
        direcao = jogador.transform.position - transform.position;
       //Equa��o para achar o angulo certo.
        x = jogador.transform.position.x - transform.position.x;
        y = jogador.transform.position.y - transform.position.y;
        quadrante = achaQuadrante(x, y);
        p = Mathf.Sqrt(x*x + y*y);
        transform.rotation = Quaternion.Euler(0, 0, achaSeno(y / p, quadrante) -90 ) ;
        //destroi o tiro depois de um tempo criado.
        Destroy(this.gameObject, 3f);
    }

    void Update()
    {//move na dire��o que jogador estava no momento que se criou o tiro
        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + direcao.normalized * Velocidade * Time.deltaTime);
    }
    //Da o dano quando encosta no com o jogador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<StatusJogador>().SofrerDano(dano);
            spriteRenderer.enabled = false;
            Velocidade = 20;
            Instantiate(particula, this.transform);
            Destroy(this.gameObject, 0.3f);    
      
        }
        else if (!(collision.CompareTag("EditorOnly")) && !(collision.CompareTag("Enemy")))
        {
            spriteRenderer.enabled = false;
            Velocidade = 20;
            Instantiate(particula, this.transform);
            Destroy(this.gameObject, 0.3f);
        }
    }
    private int achaSeno(float numb, int quadrante) 
    {
        int angulo;
        //deicha o numb positivo
        if(numb < 0) { numb = numb * -1; }
        //acha o angulo
        if (numb < 0.0872) { angulo = 5; }
        else if(numb < 0.1736) { angulo = 1; }
        else if (numb < 0.2588) { angulo = 15; }
        else if (numb < 0.2588) { angulo =  20; }
        else if (numb < 0.4226) { angulo = 25; }
        else if (numb < 0.5) { angulo = 30; }
        else if (numb < 0.5736) { angulo = 35; }
        else if (numb < 0.6428 ) { angulo = 40; }
        else if (numb < 0.7071) { angulo = 45; }
        else if (numb < 0.7660) { angulo = 50; }
        else if (numb < 0.8192) { angulo = 55; }
        else if (numb < 0.8660) { angulo = 60; }
        else if (numb < 0.9063) { angulo = 65; }
        else if (numb < 0.9397) { angulo = 70; }
        else if (numb < 0.9659) { angulo = 75; }
        else if (numb < 0.9848) { angulo = 80; }
        else if (numb < 0.9962) { angulo = 85; }
        else { angulo = 90; }
        //regula o angulo comforme o quadrante
        if (quadrante == 2 ){ angulo = 180 - angulo;} 
        else if (quadrante == 3){ angulo += 180;}  
        else if(quadrante == 4) { angulo = 360 - angulo;}  
        return angulo;
    }
    private short achaQuadrante(float x, float y) 
    {
        if (y > 0)
        {
            if (x > 0) { return 1; } else return 2;
        }
        else if (x < 0) { return 3; } else return 4;
    }
}