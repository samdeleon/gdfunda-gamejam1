using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeChest : MonoBehaviour
{
    private Animator anim;
    private bool isAttack = false;
    private bool isClose = false;
    [SerializeField] private Transform tr;
    private GameObject playerTr;
    [SerializeField] private Transform respawnPlace;
    // Start is called before the first frame update
    void Start()
    {
        // tr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(tr.position, playerTr.transform.position);

        if (dist <= 5.0f)
        {
            isAttack = true;
        }
        else if(dist > 5 && dist <= 8.0f) //���̰� 3���ٴ� �ְ� 5���ٴ� ������
        {
            isAttack = false;
            isClose = true;
        }
        else if(dist > 18.0f)
        {
            isClose = false;
            isAttack = false;
        }
        anim.SetBool("isAttack", isAttack);
        anim.SetBool("isClose", isClose);

    }

    void OnTriggerEnter(Collider coll)
    {
        playerTr.transform.position = respawnPlace.transform.position;
    }
}
