using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoofleGang.Movement
{
    public class Motor : MonoBehaviour, IMotor
    {
        public void Move(Vector3 direction, float speed)
        {
            gameObject.transform.Translate(direction * speed * Time.deltaTime);
        }

        public void Look(Transform target)
        {
            gameObject.transform.LookAt(target);
        }
    }
}

