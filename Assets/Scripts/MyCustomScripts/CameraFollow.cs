using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform cameraTarget; //our player
    [SerializeField] private Vector3 offset; //our camera
    [SerializeField] private float smoothTime = 0.3f;
    //This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 cameraVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - cameraTarget.position; //camera positon - player position
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = cameraTarget.position + offset;
        //smooth damp will gradually change a vector towards a desired goal over time.
        //camera position = Smooth Damp of this 
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothTime);

        //make the camera's transform look at player transform.
        transform.LookAt(cameraTarget);

    }
}
