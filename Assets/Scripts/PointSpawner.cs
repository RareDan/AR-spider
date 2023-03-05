using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    GameObject spider;
    public GameObject point;

    void Start()
    {
        spider = GameObject.FindGameObjectWithTag("Spider");
        InvokeRepeating(nameof(SpawnPoint), 1f, 2f);
    }

    void SpawnPoint()
    {
        float spawnX = spider.transform.position.x + Random.Range(-3, 3); // spider.x in radius 3m
        float spawnY = spider.transform.position.y + spider.transform.localScale.y;// spider.y + height spider
        float spawnZ = spider.transform.position.z + Random.Range(-4, 4);// spider.z +- 4m

        Vector3 spawnPos = new Vector3(spawnX, spawnY, spawnZ);
        Instantiate(point, spawnPos, transform.rotation);
    }
}
