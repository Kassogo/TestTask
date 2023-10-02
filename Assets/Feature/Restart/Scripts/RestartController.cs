using UnityEngine;
using TestTask.Initialization;
using TestTask.Player.Model.Interface;
using TestTask.Inventory.Controller.Interface;
using UnityEngine.SceneManagement;

namespace TestTask.Restart.Controller
{
    using View;

    /// <summary>
    /// Контроллер для рестарта игры при смерти игрока.
    /// </summary>
    public class RestartController : MonoBehaviour, IInitializable, IInitializable<IPlayerModel>, IInitializable<IInventoryController>
    {
        [SerializeField] private RestartView view;

        private IPlayerModel _player;
        private IInventoryController _inventoryController;
        private bool _needSave = true;

        public void Init(IPlayerModel data)
        {
            _player = data;
            _player.OnDeath += OpenRestartMenu;
        }

        public void Init(IInventoryController data)
        {
            _inventoryController = data;
        }

        private void OnDestroy()
        {
            _inventoryController.SaveData(_needSave);
            _player.OnDeath -= OpenRestartMenu;
        }

        private void OpenRestartMenu()
        {
            view.OpenRestartMenu();
            _needSave = false;
            view.OnRestart += RestartLevel;
        }

        private void RestartLevel()
        {
            view.OnRestart -= RestartLevel;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
