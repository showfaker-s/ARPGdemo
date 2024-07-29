using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieCamera : MonoBehaviour
{
    public float speed = 10;
    public float posZ = -20;
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.z < posZ)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
