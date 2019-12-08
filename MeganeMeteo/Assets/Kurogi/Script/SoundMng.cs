using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundMng : SingletonBase<SoundMng>
{
    #region 定義
    public enum BGMTag
    {
        Title,
        GameScene,
        Result,
        BGMTagNum,
    }
    public enum SETag
    {
        Cursor,
        Select,
        Shoot,
        Bomb,
        MilkyRoad,
        SETagNum,
    }
    #endregion

    AudioSource bgmSource;
    AudioSource seSource;

    #region property

    [SerializeField]
    AudioClip[] bgmList = new AudioClip[(int)BGMTag.BGMTagNum];
    [SerializeField]
    AudioClip[] seList = new AudioClip[(int)SETag.SETagNum];
    #endregion

    public bool IsPlayBGM { get{ return bgmSource.clip != null; }}
    public bool IsPauseBGM { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        var sources = GetComponents<AudioSource>();
        bgmSource = sources[0];
        seSource = sources[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM(BGMTag tag)
    {
        if (!IsPlayBGM)
        {
            bgmSource.clip = bgmList[(int)tag];
            bgmSource.Play();
        }
    }

    public void PlaySE(SETag tag)
    {
        seSource.clip = seList[(int)tag];
        seSource.Play();
    }

    public void RestartBGM()
    {
        if (IsPlayBGM && IsPauseBGM)
        {
            bgmSource.Play();
            IsPauseBGM = false;
        }
    }

    public void PauseBGM()
    {
        if (IsPlayBGM && !IsPauseBGM)
        {
            bgmSource.Pause();
            IsPauseBGM = true;
        }
    }

    public void StopBGM()
    {
        if (IsPlayBGM)
        {
            bgmSource.Stop();
            bgmSource.clip = null;
        }
    }
}
