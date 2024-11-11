using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public Button button;
    public int difficulty;
    GameManager gameManager;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    void SetDifficulty(){
        gameManager.StartGame(difficulty);
        Debug.Log(button.gameObject.name + " was clicked.");
    }
}
