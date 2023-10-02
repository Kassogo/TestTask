using TestTask.Initialization;
using UnityEngine;
using UnityEngine.UI;

namespace TestTask.Enemy.View
{
    using Interface;
    using Model.Interface;

    /// <summary>
    /// Вьюшка врага.
    /// </summary>
    public class EnemyView : MonoBehaviour, IEnemyView, IInitializable, IInitializable<IEnemyModel>
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject enemy;
        [SerializeField] private Slider slider;
        private IEnemyModel _model;

        private bool _isRight = true;

        public void Move(bool isMove)
        {
            animator.SetBool("Move", isMove);
        }

        public void Rotate(bool isRight)
        {
            if(_isRight != isRight)
            {
                enemy.transform.Rotate(0, 180, 0);
                _isRight = isRight;
            }
        }

        public void Attack()
        {
            animator.SetTrigger("Attack");
        }

        public void DecreaseHealth()
        {
            slider.value = _model.Health /_model.MaxHealth;
        }

        public void Init(IEnemyModel data)
        {
            _model = data;
        }
    }
}
