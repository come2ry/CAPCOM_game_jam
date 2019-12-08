using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MainGameScene : SceneBase
{
    protected override void Start()
    {
        base.Start();
        SoundMng.Instance.PlayBGM(SoundMng.BGMTag.GameScene);
    }

    protected override void Update()
    {

    }

    //対戦ゲーム終了
    public void EndMainGame()
    {
        FadeMng.Instance.RequestFade();
        StartCoroutine(ChangeScene());
    }

    //勝者を設定
    public void SetWinner(PLAYERS winner)
    {
        DataManager.Instance.SetWinPlayer(winner);
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.1f);
        while (FadeMng.Instance.IsFade)
            yield return new WaitForSecondsRealtime(0.1f);

        SoundMng.Instance.StopBGM();
        SceneDirector.NextScene();
        yield break;
    }
}
