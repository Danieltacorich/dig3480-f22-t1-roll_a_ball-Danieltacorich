using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;
    float rotspeed;
    public float speed;
    float WPradius = 1;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(waypoints[current].transform.position, Transform.position) < WPradius)
        {
            current = Random.Range(0,waypoints.Length);
            if (current >= waypoints.Length)
            {
                Current = 0;
            }
            transform.position = Vector3.MoveTowards(Transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
    }
}
