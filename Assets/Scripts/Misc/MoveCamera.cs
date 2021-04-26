using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    float destPos;
    public Vector3 cam1;
    public Vector3 cam2;
    public Vector3 cam3;
    public float speed;
    int step = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > destPos)
        {
            transform.Translate(new Vector3(0, -1 * speed, 0));
        }

    }

    public void NextPos()
    {
        step++;
        if (step == 2)
        {
            destPos = cam2.y;
        } else if (step == 3)
        {
            destPos = cam3.y;
        }
    }
}
