using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    //references to our cannonHead and Tip transforms
    //we need the cannon head to point it at the player
    [SerializeField] private Transform cannonHead;
    //we need the cannon tip for our line rendere's start point
    [SerializeField] private Transform cannonTip;
    //shooting cool down of the cannon
    [SerializeField] private float shootingCoolDown = 3.0f;
    //the strength at which we will push the player
    [SerializeField] private float laserPower = 100f;

    //bool to check if the player is in range
    private bool isPlayerInRange = false;
    //reference to our player;
    private GameObject player;
    //a variable to check if we reached the shooting cool down
    private float timeLeftToShoot = 0;
    //a reference to our line renderer
    private LineRenderer cannonLaser;

    // Start is called before the first frame update
    void Start()
    {
        cannonLaser = GetComponent<LineRenderer>();
        cannonLaser.sharedMaterial.color = Color.green;
        cannonLaser.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        timeLeftToShoot = shootingCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            cannonHead.transform.LookAt(player.transform);

            //set the first point of the laster to be the cannon tip
            cannonLaser.SetPosition(0, cannonTip.transform.position);
            //set the second point of the laser to be the player position
            cannonLaser.SetPosition(1, player.transform.position);

            //as long as the player is in range subtract the time from
            //time left to shoot
            timeLeftToShoot -= Time.deltaTime;
        }

        if(timeLeftToShoot <= shootingCoolDown * 0.5)
        {
            cannonLaser.sharedMaterial.color = Color.red;
        }

        if(timeLeftToShoot <= 0)
        {
            Vector3 directionToPushBack = player.transform.position - cannonTip.transform.position;
            player.GetComponent<Rigidbody>().AddForce(directionToPushBack * laserPower,ForceMode.Impulse);
            timeLeftToShoot = shootingCoolDown;
            cannonLaser.sharedMaterial.color = Color.green;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            cannonLaser.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            cannonLaser.enabled = false;

            timeLeftToShoot = shootingCoolDown;
            //set the color of the laser back to green
            cannonLaser.sharedMaterial.color = Color.green;
        }
    }
}
