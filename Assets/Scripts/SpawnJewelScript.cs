using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnJewelScript : MonoBehaviour
{
    System.Random r = new System.Random();
    public GameObject[] gameObjects;
    public GameObject prefab;
    private Vector3 pos;

    void Start()
    {
        var gema = r.Next(gameObjects.Length);

        pos = gameObjects[gema].GetComponent<Transform>().position;

        Instantiate(prefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
