﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    //Food Prefab
    public GameObject smallFood;
    public GameObject bigFood;
    //Border
    private Transform border_Top;
    private Transform border_Bottom;
    private Transform border_Left;
    private Transform border_Right;

    public static bool ate;

    private int CountFood = 0;

    private float defaultDistance = 3f;
    // Use this for initialization
    void Start()
    {
        ate = false;
        //spawn food every 4 seconds, starting in 3
        border_Top = GameObject.Find("Top_Border").transform;
        border_Bottom = GameObject.Find("Bottom_Border").transform;
        border_Left = GameObject.Find("Left_Border").transform;
        border_Right = GameObject.Find("Right_Border").transform;
        Spawn(smallFood);
        CountFood = 1;
    }
    void Update()
    {
        if (ate)
        {
            if (CountFood == 5)
            {
                Spawn(bigFood);
                CountFood = 0;
            }
            else
            {
                Spawn(smallFood);
                CountFood++;
            }
        }
    }

    void Spawn(GameObject food)
    {

        Vector3 spawnPos;
        float x = Mathf.Round(Random.Range(border_Left.position.x + 6f, border_Right.position.x - 6f)) + 0.5f;

        float z = Mathf.Round(Random.Range(border_Top.position.z - 6f, border_Bottom.position.z + 6f)) + 0.5f;

        spawnPos = new Vector3(x, 0.5f, z);
        if (!IsRock(spawnPos, CreatEnvironment.listRock))
        {
            Instantiate(food, spawnPos, Quaternion.identity,this.transform);
            ate = false;
        }
        else return;
    }

    bool IsRock(Vector3 pos, List<Vector3> listRock)
    {
        foreach (var posRock in listRock)
        {
            if (Vector3.Distance(pos, posRock) < defaultDistance)
                return true;
        }

        return false;
    }



}
