using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CurrentRoomLocation
{
    StartingBeach,
    StartingCave1,
    StartingCave2,
    StartingCaveBossRoom,
    StartingCaveRewardRoom
}

[System.Serializable]
public class PlayerData
{
    public string id;

    public CurrentRoomLocation currentRoomLocation;
}
