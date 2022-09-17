using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    public GameObject[] 'Movement';
    int current = 0;
    float rotspeed;
    public float speed;
    float WPradius = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Movement[current].transform.position, Transform.position) < WPradius)
        {
            current = Random.Range(0,Movement.Length);
            if (current >= Movement.Length)
            {
                Current = 0;
            }
            Transform.position = Vector3.MoveTowards(Transform.position, Movement[current].transform.position, Time.deltaTime * speed);
        }
    }
}
