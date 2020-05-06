using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackController : FollowPlayer
{
    [Header("제트 엔진 회전 속도")] [Range(0, 1)]
    [SerializeField] float spinSpeed;


    void Start()
    {
        currentPos = tf_Player.position - transform.position;
    }

    
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") >0)
        {
            transform.position = Vector3.Lerp(transform.position, tf_Player.position - currentPos, Speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), spinSpeed);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.position = Vector3.Lerp(transform.position,
                                              tf_Player.position - new Vector3(currentPos.x, currentPos.y, -currentPos.z), Speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-100, 0, 0), spinSpeed);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            transform.position = Vector3.Lerp(transform.position,
                                             tf_Player.position - new Vector3(currentPos.x, currentPos.y, 0f), Speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-56, 0, 0), spinSpeed);
        }
    }
}
