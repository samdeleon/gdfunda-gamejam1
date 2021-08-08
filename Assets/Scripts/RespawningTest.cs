using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningTest : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPlace;
    
    public void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPlace.transform.position;
    }

    public void forceRespawn()
    {
        player.transform.position = respawnPlace.transform.position;
    }

}