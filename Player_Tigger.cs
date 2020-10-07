using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tigger : MonoBehaviour {

    private Player player;

    void Awake () {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    
    void OnTriggerEnter2D (Collider2D other) {
        
        if (other.CompareTag("Body")) {

            if (!player.invunerabilidade) {
                player.DanoPersonagem();
            }

        }
    }

}
