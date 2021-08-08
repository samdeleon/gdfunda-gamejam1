using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealChest : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform tr;
    private GameObject playerTr;
    [SerializeField] private GameObject exitDoor;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // tr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(tr.position, playerTr.transform.position);

        if (dist <= 3.0f)
        {
            anim.SetBool("isOpen", true);

            exitDoor.SetActive(false);

        }
    }
}
