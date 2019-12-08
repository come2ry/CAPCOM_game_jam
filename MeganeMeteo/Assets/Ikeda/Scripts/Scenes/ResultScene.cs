using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : SceneBase
{
    [SerializeField,Tooltip("リザルト表示")]
    private GameObject _ResultColum;

    [SerializeField]
    Vector3 hidePos;

    private bool _IsUpdate = false;

    protected override void Start()
    {
        base.Start();
        SoundMng.Instance.PlayBGM(SoundMng.BGMTag.Result);
        StartCoroutine(ResultEffect());
    }

    //
    //  勝者はDataManagerから取得します。
    //
    protected override void Update()
    {
        base.Update();

        if (!_IsUpdate) return;
        if (Input.GetKeyUp(KeyCode.Space) && !FadeMng.Instance.IsFade)
        {
            FadeMng.Instance.RequestFade();
            StartCoroutine(ChangeScene());
        }
    }

    private IEnumerator ResultEffect()
    {
        yield return new WaitForSeconds(1.0f);
        Vector3 pos = _ResultColum.transform.localPosition;
        _ResultColum.transform.localPosition = hidePos;
        _ResultColum.SetActive(true);

        float time = 0.0f;
        while (true)
        {
            Vector3 current = _ResultColum.transform.localPosition;
            current.x = Vector3.Slerp(hidePos, pos, time / 1.0f).x;
            _ResultColum.transform.localPosition = current;
            
            if (current == pos) break;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _IsUpdate = true;
        yield break;
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
