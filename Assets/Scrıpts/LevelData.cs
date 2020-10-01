using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "level",menuName ="Assets/Create/New Level",order = 0)]
public class LevelData : ScriptableObject
{
    public float logSizeMax;
    public float logSizeMin;
    public int logCount;
    public GameObject[] logs;

}
