using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Spawners
{
    public abstract class Spawner<T> : MonoBehaviour where T : PoolableObject
    {
        [SerializeField] protected T _prefab;

        private ObjectPool<T> _pool;
        private int _defaultSize = 10;
        private int _maxSize = 10;
        private int _spawnCount = 0;
        private int _minObjectCount = 0;

        public event Action<T> Spawned;

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
            if (_pool == null)
                return _minObjectCount;

            return _pool.CountActive;
        }
            

        public int GetCountAllObjects()
        {
            if (_pool == null)
                return _minObjectCount;

            return _pool.CountAll;
        }

        public int GetSpawnCount() => 
            _spawnCount;

        protected void GetPool()
        {
            _spawnCount++;
            _pool.Get();
        }

        protected void RemoveObject(T newObject)
        {
            _pool.Release(newObject);
        }       

        protected void FixedVelocityObject(T newObject)
        {
            if (newObject.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.velocity = Vector3.zero;
            }
        }
    }
}
