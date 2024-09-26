using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels;
    public int currentLevelID = 1;
    public Level level;

    public Player currentplayer;

    public UnitManager unitManager;
    public void LoadLevel(int levelID)
    {
        this.level = Instantiate<Level>(levels[levelID - 1]);
        this.level.unitManager = this.unitManager;
        this.level.currentplayer = this.currentplayer;
    }
}
