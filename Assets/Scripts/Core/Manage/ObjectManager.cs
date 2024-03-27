using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

namespace Core
{
    public class ObjectManager : Singleton<ObjectManager>
    {


        private Dictionary<string, object> cache = new Dictionary<string, object>();

        public void AddObject(string key, GameObject value)
        {
            if (!cache.ContainsKey(key))
            {
                cache.Add(key, value);
            }
            else
            {
                Debug.LogWarning($"Cache already contains key: {key}. Consider updating instead of adding.");
            }
        }

        // ĳ�ÿ��� �����͸� �������� �޼���
        public T GetObject<T>(string key) where T : class
        {
            if (cache.TryGetValue(key, out object value))
            {
                // T�� ���� Ÿ������ �˻�
                if (typeof(T) == typeof(GameObject))
                {
                    return value as T;
                }
                else
                {
                    // value�� GameObject���� �˻�
                    if (value is GameObject gameObject)
                    {
                        // GameObject���� T Ÿ���� ������Ʈ�� �������� �õ�
                        T component = gameObject.GetComponent<T>();
                        if (component != null)
                        {
                            return component;
                        }
                        else
                        {
                            Debug.LogWarning($"{key} �ش� Ű�� ���� ������Ʈ�� {typeof(T).Name} ������Ʈ�� ã�� �� �����ϴ�. ");
                            return null;
                        }
                    }
                    else
                    {
                        Debug.LogWarning($"Item found in cache with key: {key} is not a GameObject");
                        return null;
                    }
                }
            }
            else
            {
                Debug.LogWarning($"{key} �ش� Ű���� ���� ������Ʈ�� �������� �ʽ��ϴ�");
                return null;
            }
        }

        // ĳ�ÿ��� �����͸� ������Ʈ�ϴ� �޼���
        public void UpdateCache(string key, object newValue)
        {
            if (cache.ContainsKey(key))
            {
                cache[key] = newValue;
            }
            else
            {
                Debug.LogWarning($"No item found in cache with key: {key}. Consider adding it first.");
            }
        }

        // ĳ�ÿ��� �����͸� �����ϴ� �޼���
        public void RemoveFromObject(string key)
        {
            if (cache.ContainsKey(key))
            {
                cache.Remove(key);
            }
            else
            {
                Debug.LogWarning($"No item found in cache with key: {key} to remove.");
            }
        }

        // ĳ�ø� ������ ���� �޼���
        public void ClearObject()
        {
            cache.Clear();
        }
    }
}
