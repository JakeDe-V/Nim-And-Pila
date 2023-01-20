﻿using System.Collections;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public static SaveData current;

    public PlayerProfile profile;

    public List<PlayerData> playerData;
    
    /*private static SaveData _current;
    public static SaveData current
    {
        get
        {
            if(_current == null)
            {
                _current = new SaveData();
            }

            return _current;
        }
    }

    public PlayerProfile profile;
    public int currentRoomLocation;
    */
}