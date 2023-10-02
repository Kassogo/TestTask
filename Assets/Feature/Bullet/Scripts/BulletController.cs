using UnityEngine;
using TestTask.Damage.Interface;

namespace TestTask.Bullet.Controller
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float damage;
        [SerializeField] private float speed;

        private IDamageble _target;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.gameObject.TryGetComponent<IDamageble>(out _target))
            {
                _target.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rigidbody.velocity += ((Vector2.right * transform.right.x) + (Vector2.up * transform.right.y)) * speed;
        }
    }
}