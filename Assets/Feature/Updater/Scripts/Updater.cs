using System;

namespace TestTask.Update
{
    using Interface;
    public class Updater : IUpdater
    {
        public event Action OnUpdate;

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}
