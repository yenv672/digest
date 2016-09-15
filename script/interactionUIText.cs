﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class interactionUIText : MonoBehaviour {

    public float fadeInDeltaAlter = 5;
    public float fadeOutDeltaAlter = 5;
    Text thisImage;
    bool unfill = false;
    bool fadeInOutStart = false;
    bool fadeInStart = false;
    bool fadeOutStart = false;
    bool fillComplete = false;

    // Use this for initialization
    void Start()
    {
        thisImage = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

       

        if (fadeInOutStart && (!fadeOutStart && !fadeInStart))
        {
            if (!fillComplete)
            {
                fadeOut();
            }
            else
            {
                fadeIn();
            }
        }

        if (fadeInStart)
        {
            //print("fade in ");
            thisImage.color = Color.Lerp(thisImage.color, new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, 0), Time.deltaTime * fadeInDeltaAlter);
            if (thisImage.color.a < 0.01f)
            {
                thisImage.color = new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, 0);
                fadeInOutStart = false;
                fadeInStart = false;
                thisImage.enabled = false;
            }
        }

        if (fadeOutStart)
        {
            //print("fade out ");
            thisImage.color = Color.Lerp(thisImage.color, new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, 1), Time.deltaTime * fadeOutDeltaAlter);
            if (thisImage.color.a > 0.99f)
            {
                thisImage.color = new Color(thisImage.color.r, thisImage.color.g, thisImage.color.b, 1);
                fadeOutStart = false;
                fillComplete = true;
            }
        }
    }

    public void fadeOut()
    {
        if (!thisImage.enabled) thisImage.enabled = true;
        fadeOutStart = true;
    }

    public void fadeIn()
    {
        if (!thisImage.enabled) thisImage.enabled = true;
        fadeInStart = true;
    }

    public void fadeInfadeOut()
    {
        thisImage.enabled = true;
        fadeInOutStart = true;
        fillComplete = false;
    }

}
