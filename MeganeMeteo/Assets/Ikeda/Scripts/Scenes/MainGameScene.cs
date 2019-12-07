using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MainGameScene : SceneBase
{
    protected override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            SceneDirector.NextScene();
    }

    //対戦ゲーム終了
    public void EndMainGame()
    {
        SceneDirector.NextScene();
    }

    //勝者を設定
    public void SetWinner(PLAYERS winner)
    {
        DataManager.Instance.SetWinPlayer(winner);
    }
}
