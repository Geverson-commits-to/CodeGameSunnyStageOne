using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hud : MonoBehaviour {
    
    public Sprite[] bar;
    public Image vidaUI;

    private Player player;

    // Start is called before the first frame update
    void Awake () {
        player = GameObject.Find("Player").GetComponent<Player> ();
    }

    // Update is called once per frame
    void Update() {
        vidaUI.sprite = bar [player.vida];
    }
}
