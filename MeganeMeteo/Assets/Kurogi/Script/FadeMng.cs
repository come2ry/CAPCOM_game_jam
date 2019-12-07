using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeMng : SingletonBase<FadeMng>
{
    #region 定義
    enum FadeState
    {
        FadeIn,
        Invisible,
        FadeOut,
        Visible,
        FadeStateNum,
    }
    #endregion

    FadeState fadeState = FadeState.Visible;
    Image fadeFilter;
    bool fadeRequest;

    float fadeOutTimer = 0.0f;
    float fadeInTimer = 0.0f;
    [SerializeField]
    float FadeOutTimeMax = 2.0f;
    [SerializeField]
    float FadeInTimeMax = 2.0f;

    public bool IsVisible
    {
        get
        {
            return fadeState == FadeState.Visible;
        }
    }

    public bool IsInvisible
    {
        get
        {
            return fadeState == FadeState.Invisible;
        }
    }

    public bool IsFade
    {
        get
        {
            return fadeState == FadeState.FadeIn || fadeState == FadeState.FadeOut;
        }
    }

    public delegate void Callback_Invisible();
    public delegate void Callback_Visible();

    public Callback_Invisible onInvisible;
    public Callback_Visible onVisible;

    // Start is called before the first frame update
    void Start()
    {
        fadeFilter = GetComponentInChildren<Image>();
        onVisible = onVisibleBase;
        onInvisible = onInvisibleBase;
    }

    // Update is called once per frame
    void Update()
    {
        switch(fadeState)
        {
            case FadeState.Invisible:
                if (fadeRequest)
                {
                    onInvisible();
                    fadeOutTimer = 0.0f;
                    fadeState = FadeState.FadeOut;
                    fadeRequest = false;
                }
                break;
            case FadeState.Visible:
                if (fadeRequest)
                {
                    onVisible();
                    fadeInTimer = 0.0f;
                    fadeState = FadeState.FadeIn;
                    fadeRequest = false;
                }
                break;
            case FadeState.FadeIn:
                fadeInTimer += Time.deltaTime;
                if(fadeInTimer > FadeInTimeMax)
                {
                    fadeInTimer = FadeInTimeMax;
                    fadeState = FadeState.Invisible;
                }
                fadeFilter.color = new Color(0, 0, 0, (fadeInTimer / FadeInTimeMax));
                break;
            case FadeState.FadeOut:
                fadeOutTimer += Time.deltaTime;
                if (fadeOutTimer > FadeOutTimeMax)
                {
                    fadeOutTimer = FadeOutTimeMax;
                    fadeState = FadeState.Visible;
                }
                fadeFilter.color = new Color(0, 0, 0, (1.0f - fadeOutTimer / FadeOutTimeMax));
                break;
        }
    }

    private void onVisibleBase()
    {
        // とりあえず何もなし
    }

    private void onInvisibleBase()
    {
        // とりあえず何もなし
    }

    public void RequestFade()
    {
        fadeRequest = true;
    }
}
