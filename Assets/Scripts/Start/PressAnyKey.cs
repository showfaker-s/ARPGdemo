using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    private bool isKeyDown = false;
    private GameObject btnContainer;
    void Start()
    {
        btnContainer = this.transform.parent.Find("btnContainer").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isKeyDown == false)
        {
            if (Input.anyKey)
            {
                showBtn();

            }
        }
    }
    private void showBtn()
    {
        btnContainer.SetActive(true);
        this.gameObject.SetActive(false);
        isKeyDown = true;
    }
}
