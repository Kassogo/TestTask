using TestTask.Inventory.Item.Model;

namespace TestTask.Inventory.Take
{
    /// <summary>
    /// Интерфейс для получения предметов.
    /// </summary>
    public interface ITakeItem
    {
        /// <summary>
        /// Получение предмета.
        /// </summary>
        /// <param name="model"></param>
        public void TakeItem(ItemModel model);
    }
}
