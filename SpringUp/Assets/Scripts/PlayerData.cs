using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int gems;
    public int HI_score;
    public int saveskin;
  
    public PlayerData(PlayerScript playerscript)
    {  
        gems = playerscript.gems;
        HI_score = playerscript.HI_score;
        saveskin = playerscript.saveskin;
    }
}
