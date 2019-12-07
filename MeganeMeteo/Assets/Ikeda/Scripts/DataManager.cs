using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYERS
{
    PLAYER_1,
    PLAYER_2
}

public class DataManager : SingletonBase<DataManager>
{
    [SerializeField]
    private PLAYERS _Winner;

    //勝者を設定
    public void SetWinPlayer(PLAYERS winner)
    {
        _Winner = winner;
    }
}  
