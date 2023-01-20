using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldPositionHandler : MonoBehaviour
{
    //This is so I can set the prefab
    /*public CurrentRoomLocation currentRoomLocation;
    
    public PlayerData playerData;

    public void Start()
    {
        if (string.IsNullOrEmpty(playerData.id))
        {
            playerData.id = System.DateTime.Now.ToLongDateString() + System.DateTime.Now.ToLongTimeString() + Random.Range(0, int.MaxValue).ToString();
            playerData.currentRoomLocation = currentRoomLocation;
            SaveData.current.playerData.Add(playerData);
        }

        GameEvents.current.onLoadEvent += DestroyMe;

    }

    private void Update()
    {
        //could update playerData with live info
    }

    void DestroyMe()
    {
        GameEvents.current.onLoadEvent -= DestroyMe();
        Destroy(gameObject);
    } */
}
