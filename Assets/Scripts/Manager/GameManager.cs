using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public enum Character
    {
        E,
        R
    }
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public Character activeCharacter = Character.E;

        public Follow cameraFollow;

        public Text heartText;

        public GameObject ECharacter, RCharacter;

        public int heartCount = 0;

        public bool canChange;

        private void Awake()
        {
            MakeInstance();
            canChange = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && canChange)
            {
                switch (activeCharacter)
                {
                    case Character.E:
                        activeCharacter = Character.R;
                        ECharacter.GetComponent<Movement>().enabled = false;
                        RCharacter.GetComponent<Movement>().enabled = true;
                        cameraFollow.activeTarget = RCharacter;
                        break;
                    case Character.R:
                        activeCharacter = Character.E;
                        ECharacter.GetComponent<Movement>().enabled = true;
                        RCharacter.GetComponent<Movement>().enabled = false;
                        cameraFollow.activeTarget = ECharacter;
                        break;
                }
                SoundManager.Instance.PlayChangeSound();
            }
        }

        private void MakeInstance()
        {
            if (!Instance)
            {
                Instance = this;
            }
        }

        public void AddHeart()
        {
            heartCount++;
            heartText.text = heartCount.ToString();
        }

        public void ResetHearts()
        {
            heartCount = 0;
            heartText.text = heartCount.ToString();
        }

        public void SetPosition(Vector3 cyanPos, Vector3 purplePos)
        {
            ECharacter.transform.position = cyanPos;
            RCharacter.transform.position = purplePos;
        }
    }
}