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

        [SerializeField] private Text _spawnCount;
        [SerializeField] private Text _createCount;
        [SerializeField] private Text _activeCount;
        [SerializeField] private Spawner<T> _spawner;

        private void Awake()
        {
            UpdateInfoUI();
            _spawner.Spawned += SpawnedNewObject;
        }

        private void OnDestroy()
        {
            _spawner.Spawned -= SpawnedNewObject;
        }

        private void UpdateInfoUI()
        {
            ViewSpawnCount(_spawner.GetSpawnCount());
            ViewCreateCount(_spawner.GetCountAllObjects());
            ViewActiveCount(_spawner.GetCountActiveObjects());
        }       

        private void SpawnedNewObject(T newObject)
        {
            UpdateInfoUI();
        }

        private void ViewSpawnCount(int count)
        {
            _spawnCount.text = SpawnCount + count;
        }

        private void ViewCreateCount(int count)
        {
            _createCount.text = CreateCount + count;
        }

        private void ViewActiveCount(int count)
        {
            _activeCount.text = ActiveCount + count;
        }
    }
}

