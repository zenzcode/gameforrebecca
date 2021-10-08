using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using Shared;
using UnityEngine;
using UnityEngine.UI;

namespace Door
{
    public class Door : MonoBehaviour
    {
        public int heartCountToOpen;
        public Transform textPos;
        public Text infoText;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                if (GameManager.Instance.heartCount >= heartCountToOpen)
                {
                    GameManager.Instance.ResetHearts();
                    gameObject.AddComponent<Rigidbody2D>();
                    Invoke(nameof(DisableObject), 2f);
                    infoText.gameObject.SetActive(false);
                }
                else
                {
                    infoText.gameObject.SetActive(true);
                    infoText.transform.position = textPos.position;
                    Invoke(nameof(DisableText), 3f);
                }
            }
        }

        private void DisableText()
        {
            infoText.gameObject.SetActive(false);
        }

        private void DisableObject()
        {
            gameObject.SetActive(false);
        }
    }
}