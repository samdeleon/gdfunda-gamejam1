using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] points;
    public int nextIdx = 1;

    public float speed = 3.0f;
    public float damping = 5.0f;

    private Transform tr;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPlace;


    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = Quaternion.LookRotation(points[nextIdx].position - tr.position);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
        tr.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("WAY_POINT"))
        {
            if (nextIdx+1 >= points.Length)
            {
                nextIdx = 1;
            }
            else
                nextIdx++;
        }

        // player.transform.position = respawnPlace.transform.position;
    }
}
