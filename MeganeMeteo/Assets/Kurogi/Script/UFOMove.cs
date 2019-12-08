using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMove : MonoBehaviour
{
    enum State
    {
        Spawn,
        Move,       // 高速移動
        Flow,       // ゆらゆら
        Hit,
        Effective,  // UFO効果発動！
        Destroy,
        StateNum,
    }
    State state = State.Spawn;

    [SerializeField]
    Vector3[] targetPointList;

    [SerializeField]
    float flowSpd = 1.0f;

    float CurrentStateTimeRate
    {
        get
        {
            return Mathf.Min(1.0f,timer / stateTime[(int)state]);
        }
    }

    public Vector3 SpawnPos
    {
        get
        {
            if(targetPointList.Length > 0)
                return targetPointList[0];
            return Vector3.negativeInfinity;
        }
    }

    [SerializeField]
    float[] stateTime = new float[(int)State.StateNum];
    [SerializeField]
    float deathRotateSpd = 10.0f;

    int currentPosIndex = 0;

    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (stateTime.Length != (int)State.StateNum)
        {
            Debug.LogError("UFOのタイマーの登録数が不正です。");
        }
        if (targetPointList.Length < 2)
        {
            Debug.LogError("UFOのポジションリストが少なすぎます！２つ以上移動させてください！");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        switch (state)
        {
            case State.Spawn:
                if (timer > stateTime[(int)state])
                {
                    state = State.Move;
                }
                break;
            case State.Move:
                transform.position = Vector3.Lerp(targetPointList[currentPosIndex], targetPointList[currentPosIndex + 1],timer/stateTime[(int)state]);
                if(timer > stateTime[(int)state])
                {
                    currentPosIndex += 1;
                    if (currentPosIndex >= targetPointList.Length - 1)
                    {
                        state = State.Destroy;
                    }
                    else
                    {
                        state = State.Flow;
                    }
                    timer = 0;
                }
                break;
            case State.Flow:
                transform.position = targetPointList[currentPosIndex] + new Vector3(Mathf.Sin(timer) * flowSpd, 0, 0);
                transform.rotation = Quaternion.AngleAxis(Mathf.Cos(CurrentStateTimeRate * 180),new Vector3(0,0,1)) ;
                if (timer > stateTime[(int)state])
                {
                    state = State.Move;
                    timer = 0;
                }
                break;
            case State.Destroy:
                transform.rotation = Quaternion.AngleAxis(Mathf.Cos(CurrentStateTimeRate * deathRotateSpd) * 360, new Vector3(0, 0, 1));
                transform.localScale = new Vector3(1.0f - CurrentStateTimeRate,1.0f - CurrentStateTimeRate, 1.0f);
                if (timer > stateTime[(int)state])
                {
                    Destroy(gameObject);
                }
                break;
        }
    }
}
