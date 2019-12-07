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
}
