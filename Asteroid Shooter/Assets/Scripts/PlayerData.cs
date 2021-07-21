using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    int coinAmount;
    public PlayerData(GameData gamedata)
    {
        coinAmount = gamedata.coinAmount;
    }
}
