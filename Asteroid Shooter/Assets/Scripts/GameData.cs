using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coinAmount;
    public GameData(PlayerData playerData)
    {
        coinAmount = playerData.coinAmount;
    }
}
