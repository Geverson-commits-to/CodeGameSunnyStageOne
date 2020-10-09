using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Espinho : MonoBehaviour {   
    private Player player;
    void Awake () {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    
    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Player")) {
                player.rig.AddForce(new Vector2(0f, player.forcaPulo * 3f), ForceMode2D.Impulse);
                player.estaVivo = false;
                player.anim.SetTrigger("Morte");
                player.Circle.enabled = false;
                Invoke("ReloadLevel", 1f);
        }
    }
    void ReloadLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
