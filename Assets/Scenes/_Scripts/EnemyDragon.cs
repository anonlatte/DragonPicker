using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDragon : MonoBehaviour
{
    [Header("Set in Inspector")] public GameObject dragonEggPrefab;
    public GameObject dragonBombPrefab;
    public GameObject HealPrefab;
    public float speed = 1f;
    public float timeBetweenEggDrops = 1f;
    public float timeBetweenBombDrops = 1f;
    public float leftRightDistance = 10f;
    public float chanceDirections = 0.1f;
    public List<Action> actions = new();

    private void Start()
    {
        actions.Add(DropEgg);
        actions.Add(DropBomb);
        actions.Add(DropHeal);
        InvokeRepeating("Loads", 0.0f, timeBetweenEggDrops);
    }

    private void Update()
    {
        var pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftRightDistance)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceDirections)
        {
            speed *= -1;
        }
    }

    private void Loads()
    {
        var r = Random.Range(0, 3);
        actions[r]();
    }

    private void DropHeal()
    {
        var myVector = new Vector3(0.0f, 5.0f, 0.0f);
        var egg = Instantiate(HealPrefab);
        egg.transform.position = transform.position + myVector;
    }

    private void DropEgg()
    {
        var myVector = new Vector3(0.0f, 5.0f, 0.0f);
        var egg = Instantiate(dragonEggPrefab);
        egg.transform.position = transform.position + myVector;
    }

    private void DropBomb()
    {
        var myVector = new Vector3(0.0f, 5.0f, 0.0f);
        var egg = Instantiate(dragonBombPrefab);
        egg.transform.position = transform.position + myVector;
    }
}