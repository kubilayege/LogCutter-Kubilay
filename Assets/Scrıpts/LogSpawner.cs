using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public static LogSpawner main;
    private void Awake()
    {
        main = this;
    }


    public IEnumerator StartLevel(LevelData currentLevel)
    {
        int logCount = currentLevel.logCount;
        Log lastLog;
        while (logCount > 0)
        {
            if (Helper.IsFail())
            {
                logCount = 0;
                yield return null;
            }
            float range = Random.Range(-1f, 1f);
            lastLog = Instantiate(currentLevel.logs[Random.Range(0, currentLevel.logs.Length)]).GetComponent<Log>();
            lastLog.transform.position = transform.position + Vector3.right*range;


            yield return new WaitForSeconds(3f);
            logCount--;
            if(logCount == 0)
                lastLog.isLastLog = true;
        }

        yield return new WaitForSeconds(5f);
        
    }
}
