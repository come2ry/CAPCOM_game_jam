using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TitleScene : SceneBase
{
    [SerializeField]
    private GameObject _StartColum;

    protected override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            StartCoroutine(StartColum_Effect());
    }

    private IEnumerator StartColum_Effect()
    {
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
        yield return new WaitForSeconds(1.0f);
        SceneDirector.NextScene();
        yield break;
    }
}