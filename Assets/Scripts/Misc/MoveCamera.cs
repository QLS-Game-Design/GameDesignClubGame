using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    float startTime;
    float elapsed = 0;
    float travelTime = 0;
    Vector2 initPos;
    Vector2 destPos;

    // Start is called before the first frame update
    void Start()
    {
        MoveToPos(new Vector3(0, -10, -10), 5);
    }

    // Update is called once per frame
    void Update()
    {
        elapsed = Time.time - startTime;

    }

    public void MoveToPos(Vector3 pos, float time)
    {
        initPos = transform.position;
        startTime = Time.time;
        travelTime = time;
    }
}
