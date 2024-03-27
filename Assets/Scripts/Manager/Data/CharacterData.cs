using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    [System.Serializable]
    public class  CharacterInfo
    {
        public string characterName;
        public int maxHp;
        public int curHp;
        public float moveSpeed;
        public int attack;
        public int defense;
        public int level;
        public int curExp;
        public int expForNext;

    }

    [CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
    public class CharacterData : ScriptableObject
    {
        public List<CharacterData> data;

    }
}
