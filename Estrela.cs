using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrela : MonoBehaviour
{
    private SpriteRenderer Sprite;
    private CircleCollider2D Circulo;

    public GameObject item;
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        Circulo = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D (Collider2D collider) {
        if(collider.gameObject.tag == "Player") {

            Sprite.enabled = false;
            Circulo.enabled = false;
            item.SetActive(true);

            GameController.atribuidor.totalScore += Score;
            GameController.atribuidor.AtualizarTextScore();
            
            Destroy(gameObject, 0.25f);
        }
    }
}
