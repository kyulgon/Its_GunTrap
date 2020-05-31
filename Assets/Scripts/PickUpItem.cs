using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Gun[] guns;

    GunController theGc;

    private void Start()
    {
        theGc = FindObjectOfType<GunController>();
    }

    const int NORMAL_GUN = 0;

    private void OnTriggerEnter(Collider other)
    {

        if(other.transform.CompareTag("Item"))
        {
            Item item = other.GetComponent<Item>();

            if(item.itemType == ItemType.Score)
            {
                SoundManager.instance.PlaySoundEffect("Score");
                ScoreManager.extraScore += item.extraScore;
            }
            else if(item.itemType == ItemType.NormalGun_Bullet)
            {
                SoundManager.instance.PlaySoundEffect("Bullet");
                guns[NORMAL_GUN].bulletCount += item.extraBullet;
                theGc.BulletUiSetting();
            }

            Destroy(other.gameObject);
        }
    }

}
