using UnityEngine;
using System;

public class Shooting : MonoBehaviour
{
    public static Action _Dealing_Damage;

    private GameObject _tower;
    private TowerScript _towerScript;

    private GameObject[] target;
    public float Speed = 1f;


    private void Awake()
    {
        _tower = GameObject.Find("Tower");
        _towerScript = _tower.GetComponent<TowerScript>();
        target = _towerScript.enemy;
    }

    void Update()
    {
        ProjectileMovement();
    }

    void ProjectileMovement()
    {
        if (TowerScript.target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, TowerScript.target.transform.position, Speed * 0.02f);

            if (transform.position == TowerScript.target.transform.position)
            {
                Destroy(gameObject, .1f);
                _Dealing_Damage?.Invoke();
            }
        } else
        {
            Destroy(gameObject, .1f);
        }
    }
}
