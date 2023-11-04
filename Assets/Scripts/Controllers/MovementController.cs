using UnityEngine;

namespace Controllers
{
    public class MovementController : MonoBehaviour, IMovable
    {
        #region IMovable_Properties

        public float Speed => _speed;
        private float _speed = 10;

        #endregion
        

        #region IMovable_Methods

        public void Move(Vector3 direction)
        {
            transform.position += direction * Time.deltaTime * Speed;
        }

        #endregion
    }
}
