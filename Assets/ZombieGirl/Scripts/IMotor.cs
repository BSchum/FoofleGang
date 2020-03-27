using UnityEngine;

namespace FoofleGang.Movement
{
    public interface IMotor
    {
        void Look(Transform target);

        void Move(Vector3 direction, float speed);
    }
}
