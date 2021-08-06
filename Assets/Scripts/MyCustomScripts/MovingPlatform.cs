using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float platformSpeed = 1.0f;
    public List<Transform> waypoints;
    private int target;
    public GameObject Player;
  

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, platformSpeed * Time.deltaTime);
    }


    private void FixedUpdate()
    {
       if(transform.position == waypoints[target].position)
        {
            if(target == waypoints.Count - 1)
            {
                target = 0;
            }
            else
            {
                target++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
