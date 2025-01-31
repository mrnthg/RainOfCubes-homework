using UnityEngine;
using UnityEngine.UI;
using Spawners;

namespace ViewInfo
{
    public abstract class ViewInfo<T> : MonoBehaviour where T : PoolableObject
    {
        private const string SpawnCount = "SpawnCount: ";
        private const string CreateCount = "CreateCount: ";
        private const string ActiveCount = "ActiveCount: ";

        [SerializeField] protected Text spawnCount;
        [SerializeField] protected Text createCount;
        [SerializeField] protected Text activeCount;
        [SerializeField] protected Spawner<T> spawner;

        private void Update()
        {
            ViewSpawnCount(spawner.GetSpawnCount());
            ViewCreateCount(spawner.GetCountAllObjects());
            ViewActiveCount(spawner.GetCountActiveObjects());
        }

        protected void ViewSpawnCount(int count)
        {
            spawnCount.text = SpawnCount + count;
        }

        protected void ViewCreateCount(int count)
        {
            createCount.text = CreateCount + count;
        }

        protected void ViewActiveCount(int count)
        {
            activeCount.text = ActiveCount + count;
        }
    }
}

