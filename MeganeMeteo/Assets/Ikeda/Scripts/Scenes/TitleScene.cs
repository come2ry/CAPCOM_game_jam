using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TitleScene : SceneBase
{
    [SerializeField]
    private GameObject _StartColum;

    private bool _IsEffect = false;

    protected override void Start()
    {
        base.Start();
        SoundMng.Instance.PlayBGM(SoundMng.BGMTag.Title);
    }

    protected override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !_IsEffect)
        {
            SoundMng.Instance.PlaySE(SoundMng.SETag.Select);
            StartCoroutine(StartColum_Effect());
        }
    }

    private IEnumerator StartColum_Effect()
    {
        _IsEffect = true;
        float time = 0.0f;
        while (true)
        {
            _StartColum.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            _StartColum.SetActive(true);
            if (time >= 1.0f) break;
            yield return new WaitForSeconds(0.1f);
            time += 0.2f;
        }

        FadeMng.Instance.RequestFade();

        yield return new WaitForSecondsRealtime(0.1f);
        while (FadeMng.Instance.IsFade)
            yield return new WaitForSecondsRealtime(0.1f);

        SceneDirector.NextScene();
        SoundMng.Instance.StopBGM();

        yield break;
    }
}