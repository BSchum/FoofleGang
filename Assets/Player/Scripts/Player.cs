using FoofleGang.Enemies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
        }
    }

    private void Shoot()
    {
        _animator.SetTrigger("Shoot");
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
