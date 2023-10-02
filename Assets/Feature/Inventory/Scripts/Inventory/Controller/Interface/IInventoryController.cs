namespace TestTask.Inventory.Controller.Interface
{
    using Model;
    using Item.Model;

    /// <summary>
    /// Интерфейс контролера инвентаря.
    /// </summary>
    public interface IInventoryController
    {
        /// <summary>
        /// Модель инвентаря.
        /// </summary>
        public InventoryModel InventoryModel { get; }

        /// <summary>
        /// Инициализация.
        /// </summary>
        public void Init();

        /// <summary>
        /// Удаление предмета.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool DeleteItem(string name, int count);

        /// <summary>
        /// Удаление предмета.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public void DeleteItem(ItemModel item);

        /// <summary>
        /// Добавление предмета.
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(ItemModel item);

        /// <summary>
        /// Нужно ли сохранить инвентарь.
        /// </summary>
        /// <param name="isSave"></param>
        public void SaveData(bool isSave);
    }
}
