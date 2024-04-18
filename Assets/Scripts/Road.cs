using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 lastPos;
    public float offset = 0.7071068f;

    private int roadCount = 0;
    
    //start creating procedurally generated road
    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 0.5f);
    }

    //create random road
    public void CreateNewRoadPart()
    {
        Debug.Log("Create new road part");
        //create var for spawn positoin of new road part
        Vector3 spawnPos = Vector3.zero;

        //define how spawnPos is spawned
        float chance = Random.Range(0, 100);
        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }else
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);

        //instantiate game object (what, where, how)
        GameObject g = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));

        //update last position with our newly created roadpart
        lastPos = g.transform.position;

        //incremante road count
        roadCount++;
        //use modulo to know if we reach a multiple of 5,
        //and if yes add crystal on roadpart
        if(roadCount % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
