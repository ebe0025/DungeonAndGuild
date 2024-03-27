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

        // 캐시에서 데이터를 가져오는 메서드
        public T GetObject<T>(string key) where T : class
        {
            if (cache.TryGetValue(key, out object value))
            {
                // T가 같은 타입인지 검사
                if (typeof(T) == typeof(GameObject))
                {
                    return value as T;
                }
                else
                {
                    // value가 GameObject인지 검사
                    if (value is GameObject gameObject)
                    {
                        // GameObject에서 T 타입의 컴포넌트를 가져오려 시도
                        T component = gameObject.GetComponent<T>();
                        if (component != null)
                        {
                            return component;
                        }
                        else
                        {
                            Debug.LogWarning($"{key} 해당 키에 게임 오브젝트에 {typeof(T).Name} 컴포넌트를 찾을 수 없습니다. ");
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
                Debug.LogWarning($"{key} 해당 키값에 대한 오브젝트는 존재하지 않습니다");
                return null;
            }
        }

        // 캐시에서 데이터를 업데이트하는 메서드
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

        // 캐시에서 데이터를 제거하는 메서드
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

        // 캐시를 완전히 비우는 메서드
        public void ClearObject()
        {
            cache.Clear();
        }
    }
}
