using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultText : MonoBehaviour
{
    TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.SetWinPlayer(PLAYERS.PLAYER_2);

        _text = GetComponent<TextMeshProUGUI>();
        if (DataManager.Instance.Winnder == PLAYERS.PLAYER_1)
            _text.text = "Player1";
        else
            _text.text = "Player2";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
