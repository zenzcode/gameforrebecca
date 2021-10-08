using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        public AudioSource backgroundSource, jumpSource, deathSound, pickupSound, changeSound, typeSound;
        private bool deathSoundPlayed;

        public void PlayJumpSound()
        {
            jumpSource.Play();
        }

        public void PlayTypeSound()
        {
            typeSound.Play();
        }

        public void PlayDeathSound()
        {
            if (!deathSound.isPlaying && !deathSoundPlayed)
            {
                deathSound.Play();
                deathSoundPlayed = true;
            }
        }

        public void PlayChangeSound()
        {
            changeSound.Play();
        }
        
        public void PlayPickupSound()
        {
            pickupSound.Play();
        }
        private void Awake()
        {
            MakeInstance();
        }

        private void MakeInstance()
        {
            if (!Instance)
            {
                Instance = this;
            }
        }
    }
}