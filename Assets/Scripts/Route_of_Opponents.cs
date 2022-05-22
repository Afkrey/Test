using UnityEngine;

public class Route_of_Opponents : MonoBehaviour
{
    //public UIController HealthInterface;  // UI разработка!!!

    public GameObject[] Cube;
    public float Speed = 5f;
    private int point = 0;
    private bool passed = false;

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        if (Cube[point] != null && passed == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, Cube[point].transform.position, Speed * 0.02f);
            Vector3 direction = (Cube[point].transform.position - transform.position).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-direction), Time.deltaTime * 10f);

            if (transform.position == Cube[point].transform.position)
            {
                if (point == Cube.Length - 1)
                {
                    passed = true;
                    //HealthInterface.HealthInterface -= 1;  //UI разработка!!!
                    //HealthInterface.GoldInterface += 20;
                    Destroy(gameObject, .1f);
                }
                else
                {
                    point++;
                }
            }
        }
    }
}
