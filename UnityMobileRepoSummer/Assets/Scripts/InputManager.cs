using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;

    [FormerlySerializedAs("tapRequiredToJump")] [SerializeField] private int tapsRequiredToMove = 2;
    [SerializeField] private float maxIntervalBetweenTaps;
    
    [Header("Debug Texts")]
    [SerializeField] private TextMeshProUGUI debugTouchCountNumber;
    [SerializeField] private TextMeshProUGUI debugTouchesText;

    private int tapCounter = 0;
    private float timeLeftForCounterReset;

    private void Start()
    {
        timeLeftForCounterReset = maxIntervalBetweenTaps;
    }

    void Update()
    {
        // if (Input.touchSupported)
        // {
        Debug.Log("This is debug!");
            debugTouchesText.text = string.Empty;
            int touchCount = Input.touchCount;
            if (touchCount > 0)
            {
                for (int i = 0; i < touchCount; i++)
                {
                    if (Input.touches[i].phase == TouchPhase.Began)
                    {
                      
                    }
                }
            }

            timeLeftForCounterReset -= Time.deltaTime;
            if (timeLeftForCounterReset <= 0)
            {
                tapCounter = 0;
                timeLeftForCounterReset = maxIntervalBetweenTaps;
            }
            //   }
    }

    private void PlayerTapped(Touch currentTouch)
    {
        tapCounter++;
        if (tapCounter >= tapsRequiredToMove)
        {
            Vector2 forceToApply;
            tapCounter = 0;
            timeLeftForCounterReset = maxIntervalBetweenTaps;
            Resolution resolution = Screen.currentResolution;
            float middleX = resolution.width / 2f;
            if (currentTouch.position.x >= middleX)
            {
                forceToApply = (Vector2.right * 150f);
            }
            else
            {
                forceToApply = (Vector2.left * 150f);
            }
            gameManager.playerRigidBody.AddForce(forceToApply);
        }
    }
}
