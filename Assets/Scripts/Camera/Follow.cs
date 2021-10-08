using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Follow : MonoBehaviour
    {
        public GameObject activeTarget;
        public float smoothingTime = 0.5f;

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, activeTarget.transform.position,
                smoothingTime * Time.deltaTime);

            var temp = transform.position;
            temp.z = -10;
            transform.position = temp;
        }
    }