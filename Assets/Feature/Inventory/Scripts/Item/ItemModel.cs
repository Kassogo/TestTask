using System;

namespace TestTask.Inventory.Item.Model
{
    /// <summary>
    /// Модель предмета.
    /// </summary>
    [Serializable]
    public class ItemModel
    {
        public string Name;
        public int Quantity;
        public string PathImage;
    }
}
