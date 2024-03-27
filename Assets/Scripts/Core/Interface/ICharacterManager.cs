using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface ICharacterManager
    {
        public void CreateCharacter(string name, Vector2 position, Transform parent = null, bool isActive = true);
    }
}
