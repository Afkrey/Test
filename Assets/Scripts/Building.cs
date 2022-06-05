using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject Cannonball;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Instantiate(Cannonball, transform.position, new Quaternion(0f, 0f, 0f, 0f));
        Destroy(gameObject);
    }
}
