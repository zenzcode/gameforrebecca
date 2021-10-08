using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pressure
{
    public class PressurePlate : MonoBehaviour
    {
        public bool isCyan, isPurple;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (isCyan && other.gameObject.name == "Player_E_BOY")
            {
                PlateManager.Instance.blueOn = true;
            }

            if (isPurple && other.gameObject.name == "Player_R_Girl")
            {
                
                PlateManager.Instance.purpleOn = true;
            }
        }
    }
}
