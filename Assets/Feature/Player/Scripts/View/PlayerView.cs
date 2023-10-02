using UnityEngine;
using UnityEngine.UI;
using TestTask.Initialization;

namespace TestTask.Player.View
{
    using Model.Interface;
    using Interface;

    /// <summary>
    /// ¬ьюшка игрока.
    /// </summary>
    public class PlayerView : MonoBehaviour, IPlayerView, IInitializable, IInitializable<IPlayerModel>
    {
        [SerializeField] private Transform weapon;
        [SerializeField] private SpriteRenderer spriteWeapon;
        [SerializeField] private Slider slider;
        private IPlayerModel _model;

        private float _angleToTarget;
        private Vector3 _vectorToTarget;

        public void RotateWeapon(Vector3 target)
        {
            _vectorToTarget = target - weapon.position;

            spriteWeapon.flipY = _vectorToTarget.x < 0 ? true : false;

            _angleToTarget = Mathf.Atan2(_vectorToTarget.y, _vectorToTarget.x) * Mathf.Rad2Deg;
            weapon.rotation = Quaternion.AngleAxis(_angleToTarget, Vector3.forward);
        }


        public void StopRotateWeapon()
        {
            spriteWeapon.flipY = false;
            weapon.rotation = Quaternion.identity;
        }

        public void DecreaseHealth()
        {
            slider.value = _model.Health / _model.MaxHealth;
        }

        public void Init(IPlayerModel data)
        {
            _model = data;
        }
    }
}
