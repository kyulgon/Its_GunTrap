using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [Header("현재 장착된 총")]
    [SerializeField] Gun currentGun;

    float currentFireRate;

    [SerializeField] Text txt_CurrentGunBullet;


    void Start()
    {
        currentFireRate = 0;
        BulletUiSetting();

    }

    public void BulletUiSetting()
    {
        txt_CurrentGunBullet.text = "x " + currentGun.bulletCount;
    }

    
    void Update()
    {
        FireRateCale();
        TryFire();
        LockOnMouse();

    }

    void FireRateCale()
    {
        if(currentFireRate > 0)
        {
            currentFireRate -= Time.deltaTime;
        }
    }


    void TryFire()
    {
        if(Input.GetButton("Fire1") && currentGun.bulletCount >0)
        {
            if(currentFireRate <= 0)
            {
                currentFireRate = currentGun.fireRate;
                Fire();
            }
              
        }
    }

    void Fire()
    {
        currentGun.bulletCount--;
        BulletUiSetting();

        currentGun.animator.SetTrigger("GunFire");
        SoundManager.instance.PlaySoundEffect(currentGun.sound_Fire);

        currentGun.ps_MuzzleFlash.Play();

        var clone = Instantiate(currentGun.go_Bullet_Prefab, currentGun.ps_MuzzleFlash.transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * currentGun.speed);
    }

    void LockOnMouse()
    {
        Vector3 camerPos = Camera.main.transform.position; // 메인 카메라의 좌표를 camerPos에 저장
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camerPos.x)); // 카메라 화면상의 좌표를 실제 3D좌표로 치환
        Vector3 target = new Vector3(0f, mousePos.y, mousePos.z);
        transform.LookAt(target);
    }
}
