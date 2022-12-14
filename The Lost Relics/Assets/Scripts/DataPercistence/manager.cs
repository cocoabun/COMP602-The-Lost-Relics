using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class manager : MonoBehaviour, IDataPercistence
{

    public void LoadData(GameData data)
    {
        //load the saved data
        Debug.Log("Loading game data from game");
        this.transform.position = data.playerPosition;
        CurrentCoins.numCoins = data.coins_balance;
        Health.CurrentHealth = data.current_health;
        RelicsCollected.numRelics = data.relics;
        Health.MaxHealth = data.max_health;
        Keys.numKeys = data.keys_balance;
        HealthPot.numberOfPotions = data.healthPotion_balance;
        MaxUpgrade.numberOfMaxPotions = data.maxHealthPotion_balance;


    }

    public void SaveData(ref GameData data)
    {
        //save the data

        data.playerPosition = this.transform.position;
        data.coins_balance = CurrentCoins.numCoins;
        data.relics = RelicsCollected.numRelics;
        data.current_health = Health.CurrentHealth;
        data.max_health = Health.MaxHealth;
        data.keys_balance = Keys.numKeys;
        data.healthPotion_balance = HealthPot.numberOfPotions;
        data.maxHealthPotion_balance = MaxUpgrade.numberOfMaxPotions;
        //  data.scene = SceneManager.GetActiveScene().name;

    }


}

