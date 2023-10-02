using UnityEngine;

namespace TestTask.Inventory.Item
{
    using Model;
    using Take;

    /// <summary>
    /// Предмет GameObject.
    /// </summary>
    public class ItemGameObject : MonoBehaviour
    {
        [SerializeField] private ItemModel item;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            ITakeItem getItem;
            if (collision.gameObject.TryGetComponent<ITakeItem>(out getItem))
            {
                getItem.TakeItem(item);
                Destroy(gameObject);
            }
        }
    }
}
