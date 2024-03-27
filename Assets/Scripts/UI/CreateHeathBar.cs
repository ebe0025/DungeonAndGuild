using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CreateHeathBar : MonoBehaviour
    {
        [SerializeField]
        GameObject heathBar;
        public void CreateHeath()
        {
            Instantiate(heathBar, transform);
        }
    }
}
