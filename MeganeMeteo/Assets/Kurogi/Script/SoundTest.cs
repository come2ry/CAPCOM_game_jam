using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundTest : MonoBehaviour
{
    SoundMng mng;
    // Start is called before the first frame update
    void Start()
    {
        mng = SoundMng.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            mng.PlayBGM(SoundMng.BGMTag.Title);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            mng.StopBGM();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            mng.PauseBGM();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            mng.RestartBGM();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            mng.PlaySE(SoundMng.SETag.Cursor);
        }
    }
}
