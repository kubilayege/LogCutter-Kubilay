using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    Vector3 spawnPos;
    Quaternion spawnRot;
    Material logMat;

    public bool isLastLog;

    

    private void Start()
    {
        logMat = GetComponent<MeshRenderer>().material;
        spawnPos = transform.position;
        spawnRot = transform.rotation;
    }
    private void OnTriggerEnter(Collider collider)
    {
        Vector3 pPos = Player.main.transform.position;
        if (collider.CompareTag("Player"))
        {
            //transform.rotation = Quaternion.Euler(0, 0, 90);
            float xPos = transform.position.x;
            float sizeX = transform.localScale.y;
            if (Mathf.Abs(pPos.x - xPos) > sizeX)
            {
                return;
            }
            float offset = collider.bounds.size.x;
            float leftX = xPos- sizeX;
            float rightX = xPos + sizeX;

            float rightPartSize = Mathf.Abs(rightX - pPos.x)/2;
            float leftPartSize = Mathf.Abs(pPos.x-leftX)/2;

            float rightPartX = pPos.x + (rightPartSize);
            float leftPartX = pPos.x - (leftPartSize);

            GameObject leftPart = SpawnPart(leftPartSize, leftPartX, -offset, true, logMat,null);
            GameObject rightPart = SpawnPart(rightPartSize, rightPartX, offset, true, logMat,null);


            Destroy(leftPart, 3f);
            Destroy(rightPart, 3f);

            if (isLastLog)
                GameManager.main.ChangeGameState(GameStates.Win);
            Destroy(this.gameObject);
        }
        else if (collider.CompareTag("Respawn"))
        {
                GameManager.main.ChangeGameState(GameStates.Fail);

            Destroy(this.gameObject);
        }
    }

    private GameObject SpawnPart(float partSize, float partX, float offset, bool _addRigidbody, Material mat, Transform parent)
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        obj.GetComponent<MeshRenderer>().material = mat;
        
        obj.transform.localScale = new Vector3(transform.localScale.x+0.001f, partSize, transform.localScale.z+0.001f);
        obj.transform.rotation = transform.rotation;

        obj.transform.parent = parent;
        obj.transform.position = new Vector3(partX + offset, transform.position.y, transform.position.z);

        if(_addRigidbody)
            obj.AddComponent<Rigidbody>();
        //obj.GetComponent<Collider>().isTrigger = true;
        return obj;
    }

}
