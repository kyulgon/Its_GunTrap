using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("따라갈 플레이어 설정")]
    [SerializeField] Transform tf_Player;

    [Header("따라갈 스피드 조정")]
    [Range(0, 1f)] [SerializeField] float chaseSpeed;

    private float camNormalXPos;
    [SerializeField]
    [Header("부스터시 떨어질 x거리")]
    private float camJetXPos;
    private float camCurrentXPos;

    private PlayerController thePlayer;

   
    void Start()
    {
        thePlayer = tf_Player.GetComponent<PlayerController>();
        camNormalXPos = transform.position.x;

        camCurrentXPos = camNormalXPos;
    }

  
    void Update()
    {
        if (thePlayer.IsJet)
            camCurrentXPos = camJetXPos;
        else
            camCurrentXPos = camNormalXPos;


        Vector3 movePos = Vector3.Lerp(transform.position, tf_Player.position, chaseSpeed);
        float cameraPosX = Mathf.Lerp(transform.position.x, camCurrentXPos, chaseSpeed);
        transform.position = new Vector3(cameraPosX, movePos.y, movePos.z);
    }
}
