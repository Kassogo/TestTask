using System.Collections.Generic;
using TestTask.Initialization;
using TestTask.Update;
using TestTask.Update.Interface;
using UnityEngine;
using TestTask.Inventory.Controller;
using TestTask.Player.Model;
using TestTask.Enemy.Model;
using TestTask.Player.Model.Interface;
using TestTask.Enemy.Model.Interface;
using TestTask.Inventory.Controller.Interface;
using TestTask.Restart.Controller;

namespace TestTask.Fabric
{
    /// <summary>
    /// Фабрика уровня.
    /// </summary>
    public class LevelFabric : MonoBehaviour
    {
        [SerializeField] private Vector2 maxSpawnPlace;
        [SerializeField] private Vector2 minSpawnPlace;
        [Space]
        [SerializeField] private PlayerModel playerModel;
        [SerializeField] private EnemyModel enemyModel;
        [Space]
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int countEnemy;

        private List<IInitializable> _initializationObjects;

        private PlayerModel _modelPlayer;
        private List<EnemyModel> _modelsEnemy;
        private IUpdater _updater;

        private IInventoryController _inventoryController;
        private RestartController _restartController;

        private void Awake()
        {
            _initializationObjects = new();
            _modelsEnemy = new();          
            _updater = new Updater();

            InitInventory();
            InitRestartController();

            SpawnPlayer();
            for (int i = 0; i < countEnemy; i++)
                SpawnEnemy();

            for (int i = 0; i < _initializationObjects.Count; i++)
            {
                Initializable.Init<IPlayerModel>(_modelPlayer, _initializationObjects[i]);
                Initializable.Init<IUpdater>(_updater, _initializationObjects[i]);
                Initializable.Init<IInventoryController>(_inventoryController, _initializationObjects[i]);
            }
        }

        private void OnDestroy()
        {
            foreach (EnemyModel model in _modelsEnemy)
                Destroy(model);
            _modelsEnemy = null;

            Destroy(_modelPlayer);
            _modelPlayer = null;
            
            _initializationObjects = null;
        }

        private void Update()
        {
            _updater.Update();
        }

        private void SpawnEnemy()
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(minSpawnPlace.x, maxSpawnPlace.x), Random.Range(minSpawnPlace.y, maxSpawnPlace.y)),
                Quaternion.identity);
            EnemyModel modelEnemy = Instantiate(enemyModel);

            _modelsEnemy.Add(modelEnemy);

            foreach (IInitializable init in enemy.GetComponents<IInitializable>())
            {
                _initializationObjects.Add(init);
                Initializable.Init<IEnemyModel>(modelEnemy, init);
            }
        }

        private void SpawnPlayer()
        {
            GameObject player = Instantiate(playerPrefab, Vector3.one, Quaternion.identity);
            _modelPlayer = Instantiate(playerModel);

            foreach (IInitializable init in player.GetComponents<IInitializable>())
                _initializationObjects.Add(init);
        }

        private void InitInventory()
        {
            _inventoryController = GameObject.FindGameObjectWithTag("Inventory").GetComponent<IInventoryController>();
            _inventoryController.Init();
        }

        private void InitRestartController()
        {
            _restartController = GameObject.FindGameObjectWithTag("Restart").GetComponent<RestartController>();
            _initializationObjects.Add(_restartController);
        }
    }
}
