using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSystem : MonoBehaviour
{
    static public bool gameOver = false;
    private MainGameScene gameScene;
    // Start is called before the first frame update
    private void Awake()
    {
        gameScene = GetComponent<MainGameScene>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(int playerNum)
    {
        if (gameOver) return;
        if(playerNum == 1)
        {
            gameScene.SetWinner(PLAYERS.PLAYER_1);
        }
        else if(playerNum == 2)
        {
            gameScene.SetWinner(PLAYERS.PLAYER_2);
        }
        gameScene.EndMainGame();
        gameOver = true;
    }
}
