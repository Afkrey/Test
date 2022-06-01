using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpaunerScript : MonoBehaviour
{
    private GameObject _storage;
    private DataStorage _dataStorage;

    private int EnemyNumber = 1;
    private int Wave_number = 0;
    public int Number_of_Waves = 3;
    public float Time_between_waves = 20f;

    private void Awake()
    {
        _storage = GameObject.Find("DataStorage");
        _dataStorage = _storage.GetComponent<DataStorage>();

    }
    private void Update()
    {
        Wave_of_Enemies();
    }

    private void Wave_of_Enemies()
    {
        if (Wave_number < Number_of_Waves && Time.time >= Time_between_waves)
        {
            Wave_number += 1;
            Time_between_waves += 20;

            _dataStorage._enemy[EnemyNumber] = Instantiate(_dataStorage.Enemy, transform.position, new Quaternion(0f, 0f, 0f, 0f));
            EnemyNumber += 1;
        }
    }
}
