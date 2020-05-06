using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("속도 관련 변수")]
    [SerializeField ]float moveSpeed;
    [SerializeField] float jetPackSpeed;

    Rigidbody myRigid;


    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        TryMove();
        TryJet();
        
    }

    void TryMove()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Vector3 moveDir = new Vector3(0, 0, Input.GetAxisRaw("Horizontal"));
            myRigid.AddForce(moveDir * moveSpeed);
        }
    }

    void TryJet()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            myRigid.AddForce(Vector3.up * jetPackSpeed);
        }
        else
        {
            myRigid.AddForce(Vector3.down * jetPackSpeed);
        }
    }
}
