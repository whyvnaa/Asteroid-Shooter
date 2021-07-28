using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    public int coinAmount = 0;
    private void Start()
    {
        LoadData(SaveSystem.LoadPlayer());
        Debug.Log("Coins at start of round: " + coinAmount);
    }

    public void AddToCoinAmount(int amount)
    {
        coinAmount += amount;
        Debug.Log("CoinAmount now: " + coinAmount);
    }

    private void LoadData(GameData gameData)
    {
        coinAmount = gameData.coinAmount;
    }
}
