using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    Restart,
    Pass
}

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;
    public int currentLevelIndex;
    public LevelData[] levels;
    public Coroutine levelCor;
    void Awake()
    {
        main = this;
    }

    public void InitLevel(Level order)
    {
        currentLevelIndex += (int)(order);
        if (levelCor != null)
            levelCor = null;

        levelCor = StartCoroutine(LogSpawner.main.StartLevel(levels[currentLevelIndex % levels.Length]));
        UIManager.main.InfoTextUpdate(currentLevelIndex + 1);
    }


    
}
