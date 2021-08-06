using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    private enum Direction
    {
        FORWARD,
        BACKWARD,
        LEFT,
        RIGHT,
        NONE
    }

    private Direction currentDir = Direction.NONE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.InputListen();
        this.Move();
    }

    private void InputListen()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.currentDir = Direction.FORWARD;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.currentDir = Direction.BACKWARD;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            this.currentDir = Direction.LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.currentDir = Direction.RIGHT;
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            this.currentDir = Direction.NONE;
        }
    }

    private void Move()
    {
        if (this.currentDir == Direction.FORWARD)
        {
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.BACKWARD)
        {
            this.gameObject.transform.Translate(Vector3.back * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.RIGHT)
        {
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * this.speed);
        }
        else if (this.currentDir == Direction.LEFT)
        {
            this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * this.speed);
        }
    }
}
