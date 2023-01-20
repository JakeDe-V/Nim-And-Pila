using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /*public void OnSave()
    {
        SerializationManager.Save("playersave", SaveData.current);
    }

    public void OnLoad()
    {
        GameEvents.current.dispatchOnLoadEvent();

        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/playersave.save");

        /*for(int i=0; i<SaveData.current.playerData.Count; i++)
        {
            PlayerData currentPlayer = SaveData.current.playerData[i];
            GameObject obj = Instantiate(playerData[(int ])
            PlayerWorldPositionHandler playerWorldPositionHandler = obj.GetComponent<PlayerWorldPositionHandler>();
        }

    } */
}
