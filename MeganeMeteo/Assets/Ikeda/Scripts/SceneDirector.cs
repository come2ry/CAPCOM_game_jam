using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneDirector : SingletonBase<SceneDirector>
{
    public SceneBase _CurrentScene;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    //次のシーンへ
    public static void NextScene()
    {
        Instance._CurrentScene.NextScene();
    }
}
