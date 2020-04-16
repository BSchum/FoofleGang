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
        if (Input.GetButton("Fire1") && deltaT > shoot_timer && bulletsInMag > 0)
        {
            Shoot();
            deltaT = 0;
        }
    }

    private void Shoot()
    {
        _animator.SetTrigger("Fire");
        bulletsInMag -= 1;
        Ray ray = new Ray(this.transform.position, transform.forward);
        RaycastHit rHit;
        if (Physics.Raycast(ray, out rHit))
        {
            if(rHit.collider.tag == "Enemy")
            {
                rHit.collider.GetComponent<IDamageable>().TakeDamage(weapon.damage);
            }
        }
    }
}
