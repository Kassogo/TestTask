using System;
using UnityEngine;

namespace TestTask.Player.Model
{
    using Interface;
    /// <summary>
    /// SO для оружия.
    /// </summary>
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Player/Weapon"), Serializable]
    public class WeaponModel : ScriptableObject, IWeaponModel
    {
        [SerializeField] private GameObject bullet;
        [SerializeField] private string needItem;
        [SerializeField] private float cooldown;
        [SerializeField] private float distanceCanShoot;
        [SerializeField] private LayerMask layerTarget;

        public GameObject Bullet => bullet;

        public float Cooldown => cooldown;

        public float DistanceCanShoot => distanceCanShoot;

        public LayerMask LayerTarget => layerTarget;

        public string NeedItemName => needItem;
    }
}
