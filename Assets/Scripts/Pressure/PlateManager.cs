using System;
using System.Collections;
using System.Collections.Generic;
using Dialog;
using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlateManager : MonoBehaviour
{
    public static PlateManager Instance;
    public GameObject endPlat;
    public GameObject[] cage;

    public bool blueOn, purpleOn;

    public Transform cyanPosEnd, purplePosEnd;

    private void Awake()
    {
        MakeInstance();
    }

    private void Update()
    {
        if (blueOn && purpleOn)
        {
            endPlat.SetActive(true);
            
            foreach(var objectOfCage in cage)
            {
                objectOfCage.SetActive(true);
            }
            
            GameManager.Instance.SetPosition(cyanPosEnd.position, purplePosEnd.position);
            Invoke(nameof(LoadDialog), 1f);
        }
    }

    private void LoadDialog()
    {
        SceneManager.LoadScene("DialogScene");
    }

    private void MakeInstance()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }


}
