using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    //Speed
    public float speed;
    //initial position
    Vector3 initialPos;
    //range of movement
    public float rangeY = 2;
    //direction is moving
    public float direction = 1;

    void Start()
    {
        //save initial position
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //factor for acceleration of the enemy in the way down.
        float factor = direction > 0 ? 1 : 2f;
        float movementY = factor * speed * Time.deltaTime * direction;
        //Y position
        float newY = transform.position.y + movementY;
        //Mathf.Abs gave us the absolute value, because we need the positive number.
        if (Mathf.Abs(newY - initialPos.y) > rangeY){
            direction *= -1;
        }
        else
        {
            transform.position += new Vector3(0,movementY,0);
        }
    }
}
