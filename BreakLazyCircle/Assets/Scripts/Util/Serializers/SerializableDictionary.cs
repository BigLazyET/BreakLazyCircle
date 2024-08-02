using System.Collections.Generic;
using UnityEngine;

namespace Serializers
{
    [System.Serializable]
    public class SerializableDictionary<TKey, TValue>
    {
        [SerializeField]
        private List<TKey> keys;
        [SerializeField]
        private List<TValue> values;

        public Dictionary<TKey, TValue> ToDictionary()
        {
            Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
            for (int i = 0; i < keys.Count; i++)
            {
                dict[keys[i]] = values[i];
            }
            return dict;
        }

        public void FromDictionary(Dictionary<TKey, TValue> dict)
        {
            keys = new List<TKey>(dict.Keys);
            values = new List<TValue>(dict.Values);
        }
    }

    // 使用方法
    //public class Example : MonoBehaviour
    //{
    //    [SerializeField]
    //    private SerializableDictionary<string, int> myDictionary;

    //    void Start()
    //    {
    //        Dictionary<string, int> dict = myDictionary.ToDictionary();
    //        // 使用字典
    //    }
    //}
}
