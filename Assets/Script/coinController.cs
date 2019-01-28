using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 100;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float angleRot = Time.deltaTime * rotationSpeed;
        transform.Rotate(Vector3.right * angleRot);
    }
}
