using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("속도 관련 변수")]
    [SerializeField ]float moveSpeed;
    [SerializeField] float jetPackSpeed;

    Rigidbody myRigid;

    public bool IsJet { get; private set; } // 속성이라 부르며, 변수의 참조와 수정을 따로 관리 가능

    [Header("파티클 시스템(부스터)")]
    [SerializeField] ParticleSystem ps_LeftEngin;
    [SerializeField] ParticleSystem ps_RightEngin;

    private AudioSource audioSource;

    JetEngineFuelManager theFuel;

    void Start()
    {
        IsJet = false; // 초기 값
        myRigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        theFuel = FindObjectOfType<JetEngineFuelManager>();
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
        if(Input.GetKey(KeyCode.Space) && theFuel.IsFuel)
        {
            if(!IsJet)
            {
                ps_LeftEngin.Play();
                ps_RightEngin.Play();
                audioSource.Play();
                IsJet = true;
            }
           

            myRigid.AddForce(Vector3.up * jetPackSpeed);
        }
        else
        {
            if (IsJet)
            {
                ps_LeftEngin.Stop();
                ps_RightEngin.Stop();
                audioSource.Stop();
                IsJet = false;
            }

            myRigid.AddForce(Vector3.down * jetPackSpeed);
        }
    }
}
