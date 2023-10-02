namespace TestTask.Initialization
{
    /// <summary>
    /// Интерфейс для инициализации компонентов.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IInitializable<T> : IInitializable
    {
        public void Init(T data);
    }
    /// <summary>
    /// Интерфейс для объектов, которым нужна инициализация компонентов.
    /// </summary>
    public interface IInitializable { }


    public static class Initializable
    {
        /// <summary>
        /// Метод для инициализации компонентов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="initializableObject"></param>
        public static void Init<T>(T data, IInitializable initializableObject)
        {
            if (initializableObject is IInitializable<T> initializable)
                initializable.Init(data);
        }
    }
}


