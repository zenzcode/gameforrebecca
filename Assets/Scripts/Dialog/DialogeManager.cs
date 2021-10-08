using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dialog
{
    public class DialogeManager : MonoBehaviour
    {
        public static DialogeManager Instance;
        public string[] blueText;
        public string[] purpleText;

        public string currentBlue, currentPurple;

        public Text blueTextObject, purpleTextObject, endText;

        public int blueIndex, purpleIndex;

        
        public bool blueTurn;

        private void Start()
        {
            blueTurn = true;
            StartCoroutine(Type());
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
        


        private IEnumerator Type()
        {
            if (blueTurn)
            {
                for (var i = 0; i <= blueText[blueIndex].Length; i++)
                {
                    currentBlue = blueText[blueIndex].Substring(0, i);
                    blueTextObject.text = currentBlue;
                    yield return new WaitForSeconds(0.1f);   
                }
                yield return new WaitForSeconds(1f);
                blueIndex++;
                blueTurn = false;
                blueTextObject.gameObject.SetActive(false);
                purpleTextObject.gameObject.SetActive(true);
                endText.gameObject.SetActive(true);
                currentBlue = "";
                if (blueIndex != 5)
                {
                    endText.gameObject.SetActive(false);
                    StartCoroutine(Type());   
                }
            }
            else
            {
                for (var i = 0; i <= purpleText[purpleIndex].Length; i++)
                {
                    currentPurple = purpleText[purpleIndex].Substring(0, i);
                    purpleTextObject.text = currentPurple;
                    yield return new WaitForSeconds(.1f);
                }
                yield return new WaitForSeconds(1f);
                purpleIndex++;
                blueTurn = true;                
                blueTextObject.gameObject.SetActive(true);
                purpleTextObject.gameObject.SetActive(false);
                currentPurple = "";
                StartCoroutine(Type()); 
            }
        }
    }
}