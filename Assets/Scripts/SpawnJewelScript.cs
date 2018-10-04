using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class SpawnJewelScript : NetworkBehaviour
{
    System.Random r = new System.Random();
    public GameObject[] gameObjects;
    public GameObject prefab;
    private Vector3 pos;

    void Start()
    {
        if (!isServer)
        {
            return;
        }

        var gema = r.Next(gameObjects.Length);
        pos = gameObjects[gema].GetComponent<Transform>().position;
        GameObject newJewel = Instantiate(prefab, pos, Quaternion.identity);
        NetworkServer.Spawn(newJewel);

    }

    // Update is called once per frame
    void Update()
    {

    }
}