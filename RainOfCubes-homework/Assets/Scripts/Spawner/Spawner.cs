using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Spawners
{
    public abstract class Spawner<T> : MonoBehaviour where T : PoolableObject
    {
        [SerializeField] protected T _prefab;
        
        public event Action<T> Spawned;

        private ObjectPool<T> _pool;
        private int _defaultSize = 10;
        private int _maxSize = 10;
        private int _spawnCount = 0;
        private int _countActiveObjects = 0;
        private int _countAllObjects = 0;

        private void Awake()
        {
            _pool = new ObjectPool<T>(CreateObject, ActionOnGet, OnRelease, Destroy, true, _defaultSize, _maxSize);
        }

        public T CreateObject()
        {
            T newObject = Instantiate(_prefab);
            newObject.transform.SetParent(transform);
            Spawned?.Invoke(newObject);
            return newObject;
        }

        public abstract void ActionOnGet(T newObject);

        public abstract void OnRelease(T newObject);

        public int GetCountActiveObjects()
        {
            _countActiveObjects = _pool.CountActive;
            return _countActiveObjects;
        }

        public int GetCountAllObjects()
        {
            _countAllObjects = _pool.CountAll;
            return _countAllObjects;
        }

        public int GetSpawnCount()
        {
            return _spawnCount;
        }

        protected void GetPool()
        {
            _spawnCount++;
            _pool.Get();
        }

        protected void RemoveObject(T newObject)
        {
            _pool.Release(newObject);
        }       
    }
}
