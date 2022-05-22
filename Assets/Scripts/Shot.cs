using UnityEngine;

public class Shot : MonoBehaviour
{
    public TowerOptions Target;

    public float Speed = 5f;

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        if (Target.target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.target.transform.position, Speed * 0.02f);

            if (transform.position == Target.target.transform.position)
            {
                Destroy(gameObject, .1f);
            }
        }
    }

    public void SetTarget()
    {
        // Аргументы
    }
}
