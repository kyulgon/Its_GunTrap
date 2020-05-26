using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("피격 이펙트")]
    [SerializeField] GameObject go_RicocheEffect;

    [Header("총알 데미지")]
    [SerializeField] int damage;

    [Header("피격 효과음")]
    [SerializeField] string sound_Ricochet;

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        SoundManager.instance.PlaySoundEffect(sound_Ricochet);
        var clone = Instantiate(go_RicocheEffect, contactPoint.point, Quaternion.LookRotation(contactPoint.normal));

        Destroy(clone, 0.5f);
        Destroy(gameObject);
    }


}
