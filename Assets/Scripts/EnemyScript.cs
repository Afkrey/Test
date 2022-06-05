using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject _storage;
    private DataStorage _dataStorage;

    private GameObject[] Point;

    private bool passed = false;
    private int point = 0;

    public int Hp = 100;
    public float speed = 5f;

    public static int DestroyedEnemy = 0;


    private void Awake()
    {
        _storage = GameObject.Find("DataStorage");
        _dataStorage = _storage.GetComponent<DataStorage>();
        Point = _dataStorage._point;
    }

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        if (Point[point] != null && passed == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, Point[point].transform.position, speed * 0.02f);
            Vector3 direction = (Point[point].transform.position - transform.position).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-direction), Time.deltaTime * 10f);

            if (transform.position == Point[point].transform.position)
            {
                if (point == Point.Length - 1)
                {
                    passed = true;
                    DestroyedEnemy++;
                    Destroy(gameObject);
                }
                else
                {
                    point++;
                }
            }
        }
    }

    private void OnEnable()
    {
        Shooting._Dealing_Damage += Dealing_Damage;
    }

    private void OnDisable()
    {
        Shooting._Dealing_Damage -= Dealing_Damage;
    }

    void Dealing_Damage()
    {
        Hp -= 20;

        if (Hp <= 0)
        {
            Destroy(gameObject);
            DestroyedEnemy++;
        }
    }
}
