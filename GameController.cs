using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    public int totalScore;
    public Text textoScore;

    public static GameController atribuidor;
    // Start is called before the first frame update
    void Start () {
        atribuidor = this;
    }

    public void AtualizarTextScore () {
        textoScore.text = totalScore.ToString();
    }
    
}
