using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private GameObject _storage;
    private DataStorage _dataStorage;

    private float Period = 2f;

    public GameObject Cannonball;
    public GameObject[] enemy;

    private float speed = 10f;

    public static GameObject target;
    //public static int DestroyedEnemy = 0;

    private void Awake()
    {
        _storage = GameObject.Find("DataStorage");
        _dataStorage = _storage.GetComponent<DataStorage>();
        enemy = _dataStorage._enemy;

        target = enemy[EnemyScript.DestroyedEnemy];
    }

    void Update()
    {
        Self_managed();
        EnemyAttack();
        Debug.Log(EnemyScript.DestroyedEnemy);
    }

    void Self_managed()
    {
        if (enemy[EnemyScript.DestroyedEnemy] != null)
        {
            Vector3 direction = (enemy[EnemyScript.DestroyedEnemy].transform.position - transform.position - new Vector3(0f, 1.65f, 0f)).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10f);

            Transform cannonTransform = transform.Find("Gun");
            
            if (!(cannonTransform is null))
            {
                GameObject gun = cannonTransform.gameObject;
                gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, Quaternion.LookRotation(new Vector3(0f, 0f, 1f)), Time.deltaTime * speed);
            }
        }
    }


    void EnemyAttack()
    {
        if (enemy[EnemyScript.DestroyedEnemy] != null && Period < Time.time)
        {
            Instantiate(Cannonball, transform.position, new Quaternion(0f, 0f, 0f, 0f));
            Period = Time.time + 2;
        }
        else if (target == null && enemy.Length > EnemyScript.DestroyedEnemy)
            target = enemy[EnemyScript.DestroyedEnemy];
    }
}



