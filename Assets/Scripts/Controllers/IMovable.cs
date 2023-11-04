using UnityEngine;

namespace Controllers
{
    public interface IMovable
    {
        float Speed { get; }
        void Move(Vector3 direction);
    }
}
