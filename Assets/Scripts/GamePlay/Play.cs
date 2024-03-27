using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class Play : MonoBehaviour
    {
        public Transform playerSpawn1;
        public Transform playerSpawn2;
        public Transform playerSpawn3;

        public Transform[] enemySpawns;

        ICharacterManager charManager;

        private void Awake()
        {
            charManager = GetComponent<ICharacterManager>();

            charManager.CreateCharacter("Knight", playerSpawn1.position);
            charManager.CreateCharacter("Ranger", playerSpawn2.position);

            RandomSpawn("Skeleton", enemySpawns);
            RandomSpawn("Skeleton", enemySpawns);
            RandomSpawn("Skeleton", enemySpawns);
            RandomSpawn("Skeleton", enemySpawns);
        }

        private void RandomSpawn(string name, Transform[] transform)
        {
            int randomNum = Random.Range(0, transform.Length);

            charManager.CreateCharacter(name, transform[randomNum].position);
        }





    }
}
