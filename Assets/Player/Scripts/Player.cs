using FoofleGang.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Weapon weapon;
    private float shoot_timer = 0.3f;
    private float deltaT = 0;
    private int bulletsInMag = 10;

    // Start is called before the first frame update
    void Start()
    {
        shoot_timer = weapon.fireRate;
        bulletsInMag = weapon.magSize;
    }

    // Update is called once per frame
    void Update()
    {
        deltaT += Time.deltaTime;
    }

    public void Shoot()
    {
        if (deltaT > shoot_timer && bulletsInMag > 0)
        {
            _animator.SetTrigger("Fire");
            bulletsInMag -= 1;
            var camera = GameObject.Find("/AR Session Origin/AR Camera");
            Ray ray = new Ray(this.transform.position, camera.transform.TransformDirection(Vector3.forward));
            RaycastHit rHit;
            if (Physics.Raycast(ray, out rHit))
            {
                if (rHit.collider.tag == "Enemy")
                {
                    rHit.collider.GetComponent<IDamageable>().TakeDamage(weapon.damage);
                }
            }
            deltaT = 0;
        }
        //  TODO REMOVE WHEN RELOAD UI IS READY
        if (bulletsInMag == 0)
        {
            ReloadWeapon();
        }
    }

    public int GetBulletsInMag()
    {
        return this.bulletsInMag;
    }

    private void ReloadWeapon()
    {
        this.bulletsInMag = weapon.magSize;
    }
}
