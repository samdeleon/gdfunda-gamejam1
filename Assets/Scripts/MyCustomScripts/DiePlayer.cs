using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePlayer : MonoBehaviour
{
    private GameObject PlayerEntity;
    [SerializeField] Transform spawnPoint;
    // Start is called before the first frame update
    private void Start()
    {
        PlayerEntity = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerEntity.transform.position = spawnPoint.transform.position;
        }
    }
}
