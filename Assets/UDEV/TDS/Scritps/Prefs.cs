using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs 
{
   
    public static int coins
      {
          set=> PlayerPrefs.SetInt(PrefConst.COIN_KEY, value);
          get=>PlayerPrefs.GetInt(PrefConst.COIN_KEY,0);
      }
    public static int playerData
    {
        set => PlayerPrefs.SetInt(PrefConst.PLAYER_DATA_KEY, value);
        get => PlayerPrefs.GetInt(PrefConst.PLAYER_DATA_KEY, 0);
    }
    public static int playerWeaponData
    {
        set => PlayerPrefs.SetInt(PrefConst.PLAYER_WEAPON_DATA_KEY, value);
        get => PlayerPrefs.GetInt(PrefConst.PLAYER_WEAPON_DATA_KEY, 0);
    }
    public static int enemyData
    {
        set => PlayerPrefs.SetInt(PrefConst.ENEMY_DATA_KEY, value);
        get => PlayerPrefs.GetInt(PrefConst.ENEMY_DATA_KEY, 0);
    }


    public static bool IsEnoughCoins(int coinToCheck)
    {
        return coins >= coinToCheck;//coin ng choi lon hon coin dua vao 
    }
}
