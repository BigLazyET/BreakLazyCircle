using UnityEngine;
using System.Collections.Generic;

namespace Serializers
{
    [System.Serializable]
    public class SerializableDictionary1<TKey, TValue> : ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<TKey> keys = new List<TKey>();
        [SerializeField]
        private List<TValue> values = new List<TValue>();

        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        public TValue this[TKey key]
        {
            get => dictionary[key];
            set => dictionary[key] = value;
        }

        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            foreach (var kvp in dictionary)
            {
                keys.Add(kvp.Key);
                values.Add(kvp.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            dictionary.Clear();
            for (int i = 0; i < keys.Count; i++)
            {
                dictionary[keys[i]] = values[i];
            }
        }

        public void Add(TKey key, TValue value) => dictionary[key] = value;

        public bool TryGetValue(TKey key, out TValue value) => dictionary.TryGetValue(key, out value);

        public bool ContainsKey(TKey key) => dictionary.ContainsKey(key);

        // TODO: 其他字典方法的包装...
    }

    // 使用方法
    //public class Example : MonoBehaviour
    //{
    //    [SerializeField]
    //    private SerializableDictionary1<string, int> myDictionary;

    //    void Start()
    //    {
    //        myDictionary.Add("key1", 1);
    //        myDictionary.Add("key2", 2);

    //        int value;
    //        if (myDictionary.TryGetValue("key1", out value))
    //        {
    //            Debug.Log("Value: " + value);
    //        }
    //    }
    //}
}
