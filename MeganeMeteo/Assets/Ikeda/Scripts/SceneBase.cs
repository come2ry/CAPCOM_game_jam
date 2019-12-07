using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBase : MonoBehaviour
{
    [SerializeField]
    private string _nextScene;

    private void Awake()
    {
        
    }

    protected virtual void Start()
    {
        SceneDirector.Instance._CurrentScene = this;
    }

    protected virtual void Update()
    {
        
    }

    public void NextScene()
    {
        //FadeOut
        if(FadeMng.Instance.IsInvisible)
            FadeMng.Instance.RequestFade();

        SceneManager.LoadScene(_nextScene);
    }
}

