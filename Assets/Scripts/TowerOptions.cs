using UnityEngine;

public class TowerOptions : MonoBehaviour
{
    private float Period = 2f;
    public GameObject Cannonball;
    public GameObject enemy; //Первый и третий способ

    public Transform target; //Второй способ
    public GameObject _cannonball;

    private float Speed = 0.1f;


    // Update is called once per frame
    void Update()
    {
        Self_managed();
        EnemyAttack();
    }

    void Self_managed()
    {
        if (enemy != null)
        {
            
            Vector3 direction = (enemy.transform.position - transform.position - new Vector3(0f, 1.65f, 0f)).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10f);

            Transform cannonTransform = transform.Find("Gun");

            //transform.LookAt(target); //Второй способ

            
            if (!(cannonTransform is null))
            {
                GameObject gun = cannonTransform.gameObject;
                gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, Quaternion.LookRotation(new Vector3(0f, 0f, 1f)), Time.deltaTime * 10f);
            }
        }
    }

    void EnemyAttack()
    {

        if (_cannonball != null)
        {
            _cannonball.transform.position = Vector3.MoveTowards(_cannonball.transform.position, enemy.transform.position, Speed);

            if (_cannonball.transform.position == enemy.transform.position)
            {
                Destroy(_cannonball, .1f);
                _cannonball = null;
            }
        } else
        {
            if (enemy != null && Period < Time.time)
            {
                //Cannonball.transform.position = transform.position;
                //Cannonball.transform.position = transform.GetChild(0).gameObject.transform.position;

                _cannonball = Instantiate(Cannonball, transform);
                Period += 1f;
            }

        }
    }
}


 //if (enemy != null && Period < Time.time)
 //{
 //  //Transform = transform.Find("Gun");
 //  Transform gunTransform = transform.Find("Gun");
 //  GameObject gunObject = gunTransform.gameObject;
 //  Vector3 pos = gunObject.transform.position;
 //  Cannonball.transform.position = pos;
 //  Instantiate(Cannonball);
 //  Period += 2;
 //}

 



