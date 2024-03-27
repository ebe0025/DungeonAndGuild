using Core;
using GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HeathBar : MonoBehaviour
    {
        [SerializeField]
        private GameObject target;

        private IHealthState targetHealthState;
        [SerializeField]
        private Vector3 offset = new Vector3(0, 1.0f, 0);
        private Camera cam;
        private Slider slider;



        private void Awake()
        {
            cam = Camera.main;
            targetHealthState = target.GetComponent<IHealthState>();
            SetSlider();
            
        }
        


        private void OnEnable()
        {
            targetHealthState.HealthChanged += UpdateHpBar;
        }
        private void OnDisable()
        {
            targetHealthState.HealthChanged -= UpdateHpBar;
        }
        private void Update()
        {
            if(target != null)
            {
                Vector3 worldPosition = target.transform.position + offset;
                Vector3 screenPosition = cam.WorldToScreenPoint(worldPosition);
                transform.position = screenPosition;
            }

        }

        private void SetSlider()
        {
            slider = GetComponent<Slider>();
            slider.maxValue = targetHealthState.MaxHp;
            slider.value = targetHealthState.CurHp;
        }
        private void UpdateHpBar(int amount)
        {
            slider.value = amount;
        }
    }


    
}
