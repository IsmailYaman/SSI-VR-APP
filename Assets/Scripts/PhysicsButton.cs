using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.Video;

//test

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed, onReleased;

    public static bool step1 = true;
    public static bool step1Left = false;
    public static bool step1Right = false;

    public static bool step2 = false;

    public static bool step3 = false;
    public static bool step3Right = false;
    public static bool step3Middle = false;
    public static bool step3Left = false;

    public static bool step4 = false;
    public static bool step5 = false;


    

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if(_isPressed && GetValue() - threshold <= 0)
            Released();

        
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }
    
    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        //Debug.Log("Pressed");
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        //Debug.Log("Released");
    }

    public void LeftButtonClick()
    {

        if (step1)
        {
            Debug.Log("Pressed1");
            step1 = true;

            step1Left = true;   
        }

        if (step2)
        {
            step3 = true;

            step3Left = true;
        }
    }

    public void MiddleButtonClick()
    {
        if (step3)
        {
            Debug.Log("Pressed2");
            step3Left = true;
        }
    }

    public void RightButtonClick()
    {
        if (step1)
        {
            Debug.Log("Pressed3");
            step1 = true;

            step1Right = true;
        }

        if (step2)
        {
            step3 = true;

            step3Left = true;
        }
    }

   

}
