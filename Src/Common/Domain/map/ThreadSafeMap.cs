using System.Collections.Generic;
using System.Linq;

namespace Ttu.Domain
{
    public class ThreadSafeMap<TKey, TValue>
    {

        # region Constructors

        public ThreadSafeMap()
        {
            Map = new Dictionary<TKey, TValue>();
        }

        # endregion

        # region Properties

        public int Count { get { return Map.Count; } }

        public TValue this[TKey key]
        {
            get { return GetValue(key); }
            set { SetValue(key, value); }
        }

        private Dictionary<TKey, TValue> Map { get; set; }

        # endregion

        # region Public Methods

        public void Clear()
        {
            lock (Map)
            {
                Map.Clear();
            }
        }

        public bool ContainsKey(TKey key)
        {
            lock (Map)
            {
                return Map.ContainsKey(key);
            }
        }

        public TValue FindOrCreate(TKey key, IThreadSafeMapValueFactory<TValue> newValueFactory, object newValueArg)
        {
            lock (Map)
            {
                // guard clause - already mapped
                TValue existingValue = GetValue(key);
                if (existingValue != null)
                {
                    return existingValue;
                }

                // guard clause - invalid factory
                if (newValueFactory == null)
                {
                    return default(TValue);
                }

                // potential has become actual
                TValue newValue = newValueFactory.CreateMapValue(newValueArg);
                Map[key] = newValue;
                return newValue;
            }
        }

        public int GetCount()
        {
            lock (Map)
            {
                return Map.Count;
            }
        }

        public TKey[] GetKeys()
        {
            lock (Map)
            {
                return Map.Keys.ToArray();
            }
        }

        public KeyValuePair<TKey, TValue>[] GetKeyValuePairs()
        {
            lock (Map)
            {
                return Map.ToArray<KeyValuePair<TKey, TValue>>();
            }
        }

        public TValue[] GetValues()
        {
            lock (Map)
            {
                return Map.Values.ToArray();
            }
        }

        public bool Remove(TKey key)
        {
            lock (Map)
            {
                return Map.Remove(key);
            }
        }

        # endregion

        # region Helper Methods

        private TValue GetValue(TKey key)
        {
            lock (Map)
            {
                TValue foundValue;
                Map.TryGetValue(key, out foundValue);
                return foundValue;
            }
        }

        private void SetValue(TKey key, TValue newValue)
        {
            lock (Map)
            {
                Map[key] = newValue;
            }
        }

        # endregion

    }
}
