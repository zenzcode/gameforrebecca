using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using Shared;
using UnityEngine;

namespace Collectable
{
    public class CollectableItem : MonoBehaviour
    {
        public GameObject particle;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tags.Player))
            {
                particle.SetActive(true);
                SoundManager.Instance.PlayPickupSound();
                Invoke(nameof(Remove), .3f);
            }
        }

        private void Remove()
        {
            gameObject.SetActive(false);
            GameManager.Instance.AddHeart();
        }
    }
}
