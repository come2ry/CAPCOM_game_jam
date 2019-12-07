using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : SceneBase
{
    [SerializeField,Tooltip("リザルト表示")]
    private GameObject _ResultColum;

    protected override void Start()
    {
        base.Start();
        _ResultColum.SetActive(true);
    }

    //
    //  勝者はDataManagerから取得します。
    //
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyUp(KeyCode.Space))
            SceneDirector.NextScene();
    }
}
