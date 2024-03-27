using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }

        void Awake()
        {
            if (_instance != null)
            {
                if (_instance != this)
                {
                    Destroy(gameObject);
                }
                return;
            }

            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
    }
}