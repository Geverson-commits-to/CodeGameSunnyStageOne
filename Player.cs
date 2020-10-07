using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float velocidade; //variavel de numeros decimais
    public float forcaPulo;
    public Rigidbody2D rig; //variavel do tipo componente rigidbody2d
    public Animator anim; //variavel do tipo componente animator
    public SpriteRenderer Sprite; //variavel do tipo component Spriter do personagem 
    public CircleCollider2D Circle;
    public bool estaVivo = true;

    bool estaPulando;
    bool puloDuplo;
    public GameObject explosao;

    public int vida;
    public bool invunerabilidade = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimentar();
        Pular();
    }
    void Movimentar()
    {
        if (estaVivo) {
            float direcao = Input.GetAxis("Horizontal"); //varia entre -1 e 1

            rig.velocity = new Vector3(direcao * velocidade, rig.velocity.y);

            if(direcao > 0f)
            {
                transform.eulerAngles = new Vector2(0f, 0f);

                if(estaPulando == false)
                {
                    anim.SetInteger("transition", 1);
                }
                
            }

            if (direcao < 0f)
            {
                transform.eulerAngles = new Vector2(0f, 180f);

                if (estaPulando == false)
                {
                    anim.SetInteger("transition", 1);
                }
            }

            if(direcao == 0)
            {
                if (estaPulando == false)
                {
                    anim.SetInteger("transition", 0);
                }
            }
        }
    }

    void Pular()
    {
        if(Input.GetButtonDown("Jump")){
            if(!estaPulando){
                rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
                puloDuplo = true;
                anim.SetInteger("transition", 2);
            } else {
                if(puloDuplo){
                    rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
                    puloDuplo = false;
                    anim.SetInteger("transition", 2);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //se colidir com o chao
        if(collision.gameObject.layer == 8)
        {
            anim.SetInteger("transition", 0);
            estaPulando = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //se colidir com o chao
        if(collision.gameObject.layer == 8)
        {
            estaPulando = true;
            anim.SetInteger("transition", 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Body"))
        {
            //perde vida
        }

        if(collision.CompareTag("Head"))
        {
            rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse); //empurra personagem
            GameObject exp = Instantiate(explosao, collision.transform.position, collision.transform.rotation); //cria explosao
            Destroy(exp, 0.5f);
            Destroy(collision.transform.parent.gameObject); //destroi inimigo
        }
    }

    IEnumerator Dano () {
        for (float i = 0f; i < 1; i += (0.1f)) {
            Sprite.enabled = false;
            yield return new WaitForSeconds (0.1f);
            Sprite.enabled = true;
            yield return new WaitForSeconds (0.1f);
        }
        invunerabilidade = false;
    }

    public void DanoPersonagem () {

        if (estaVivo) {

            invunerabilidade = true;
            vida--;
            StartCoroutine(Dano ());

            if (vida < 1) {
                estaVivo = false;
                anim.SetTrigger("Morte");
                Circle.enabled = false;
                Sprite.enabled = false;
                Invoke("ReloadLevel", 0.8f);
            }
        }
    }

    void ReloadLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
