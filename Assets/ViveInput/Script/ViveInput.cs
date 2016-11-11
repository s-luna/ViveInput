using UnityEngine;
using System.Collections;
using Valve.VR;
using System;
using System.Collections.Generic;
using System.Reflection;

public enum ButtonMask
{
    System = 0,
    ApplicationMenu = 1,
    Grip = 2,
    Axis0 = 3,
    Axis1 = 4,
    Axis2 = 5,
    Axis3 = 6,
    Axis4 = 7,
    Touchpad = 8,
    Trigger = 9,
}

public enum Controller
{
    Right = 0,
    Left = 1,
}

public static class ViveInput
{

    private class ButtonMaskTable : Hashtable
    {
        public ButtonMaskTable() : base()
        {
            base.Add(ButtonMask.System, SteamVR_Controller.ButtonMask.System);
            base.Add(ButtonMask.ApplicationMenu, SteamVR_Controller.ButtonMask.ApplicationMenu);
            base.Add(ButtonMask.Grip, SteamVR_Controller.ButtonMask.Grip);
            base.Add(ButtonMask.Axis0, SteamVR_Controller.ButtonMask.Axis0);
            base.Add(ButtonMask.Axis1, SteamVR_Controller.ButtonMask.Axis1);
            base.Add(ButtonMask.Axis2, SteamVR_Controller.ButtonMask.Axis2);
            base.Add(ButtonMask.Axis3, SteamVR_Controller.ButtonMask.Axis3);
            base.Add(ButtonMask.Axis4, SteamVR_Controller.ButtonMask.Axis4);
            base.Add(ButtonMask.Touchpad, SteamVR_Controller.ButtonMask.Touchpad);
            base.Add(ButtonMask.Trigger, SteamVR_Controller.ButtonMask.Trigger);
        }
    }

    private static float rightTriggerValue;
    private static Vector2 rightTouchPadPos;
    private static float leftTriggerValue;
    private static Vector2 leftTouchPadPos;
    private static Hashtable rightKeyTable;
    private static Hashtable leftkeyTable;
    private static ButtonMaskTable buttonMaskTable = new ButtonMaskTable();

    private static GameObject rightTrackedObj;
    private static GameObject leftTrackedObj;
    private static SteamVR_Controller.Device rightController;
    private static SteamVR_Controller.Device leftController;
    private const string leftControllerName = "Controller (left)";
    private const string rightControllerName = "Controller (right)";

    private static bool isRightTracked;
    private static bool isLeftTracked;
    private static int frameCount;

    delegate bool GetMethod(ulong buttonMask);

    private static List<GetMethod> getRightMethod = new List<GetMethod>();
    private static List<GetMethod> getLeftMethod = new List<GetMethod>();

    static void CacheCheck()
    {
        if (frameCount == Time.frameCount)
        {
            return;
        }
        else
        {
            frameCount = Time.frameCount;
            KeyUpdate();
            return;
        }
    }

    static ulong ConvertKey(ButtonMask key)
    {
        return (ulong)buttonMaskTable[key];
    }

    static bool GetSafeTable(ref Hashtable table, string key)
    {
        if (table.ContainsKey(key))
        {
            return (bool)table[key];
        }
        else
        {
            return false;
        }
    }

    static bool GetKey(Controller controller, ButtonMask key, string methodName)
    {
        CacheCheck();
        string keyName = methodName + key.ToString();
        switch (controller)
        {
            case Controller.Right:
                return GetSafeTable(ref rightKeyTable, keyName);
            case Controller.Left:
                return GetSafeTable(ref leftkeyTable, keyName);
            default:
                return false;
        }
    }

    static bool GetKey(GameObject controller, ButtonMask key, string methodName)
    {
        CacheCheck();
        string keyName = methodName + key.ToString();
        switch (controller.name)
        {
            case rightControllerName:
                return GetSafeTable(ref rightKeyTable, keyName);
            case leftControllerName:
                return GetSafeTable(ref leftkeyTable, keyName);
            default:
                Debug.Log("ViveInput.GetKey(GameObject,ButtonMask,string) UnknownControllerName.不正な値です.");
                return false;
        }
    }

    public static float GetTriggerValue(Controller controller)
    {
        switch (controller)
        {
            case Controller.Right:
                return rightTriggerValue;
            case Controller.Left:
                return leftTriggerValue;
            default:
                return 0;
        }
    }

    public static float GetTriggerValue(GameObject controller)
    {
        switch (controller.name)
        {
            case rightControllerName:
                return rightTriggerValue;
            case leftControllerName:
                return leftTriggerValue;
            default:
                Debug.Log("ViveInput.GetTrigger(GameObject) NullReferenceException.不正な値です.");
                return 0;
        }
    }

    public static Vector2 GetTouchPos(Controller controller)
    {
        switch (controller)
        {
            case Controller.Right:
                return rightTouchPadPos;
            case Controller.Left:
                return leftTouchPadPos;
            default:
                return Vector2.zero;
        }
    }

    public static Vector2 GetTouchPos(GameObject controller)
    {
        switch (controller.name)
        {
            case rightControllerName:
                return rightTouchPadPos;
            case leftControllerName:
                return leftTouchPadPos;
            default:
                Debug.Log("ViveInput.GetTouchPos(GameObject) NullReferenceException.不正な値です.");
                return Vector2.zero;
        }
    }

    public static bool GetTouchDown(Controller controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    public static bool GetTouchDown(GameObject controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    public static bool GetTouch(Controller controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    public static bool GetTouch(GameObject controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    public static bool GetTouchUp(Controller controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    public static bool GetTouchUp(GameObject controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    public static bool GetPressDown(Controller controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    public static bool GetPressDown(GameObject controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    public static bool GetPress(Controller controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    public static bool GetPress(GameObject controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    public static bool GetPressUp(Controller controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    public static bool GetPressUp(GameObject controller, ButtonMask key) { return GetKey(controller, key, MethodBase.GetCurrentMethod().Name); }

    static void KeyUpdate()
    {
        rightKeyTable = new Hashtable();
        leftkeyTable = new Hashtable();

        if (rightTrackedObj)
        {
            isRightTracked = true;
            SteamVR_TrackedObject rightTrackedObject = rightTrackedObj.GetComponent<SteamVR_TrackedObject>();
            rightController = SteamVR_Controller.Input((int)rightTrackedObject.index);
            rightTriggerValue = rightController.GetAxis(EVRButtonId.k_EButton_SteamVR_Trigger).x;
            rightTouchPadPos = rightController.GetAxis();
            if (getRightMethod.Count == 0)
            {
                getRightMethod = new List<GetMethod>();
                getRightMethod.Add(rightController.GetTouchDown);
                getRightMethod.Add(rightController.GetTouch);
                getRightMethod.Add(rightController.GetTouchUp);
                getRightMethod.Add(rightController.GetPressDown);
                getRightMethod.Add(rightController.GetPress);
                getRightMethod.Add(rightController.GetPressUp);
            }
        }
        else
        {
            isRightTracked = false;
            rightTrackedObj = GameObject.Find(rightControllerName);
        }

        if (leftTrackedObj)
        {
            isLeftTracked = true;
            SteamVR_TrackedObject leftTrackedObject = leftTrackedObj.GetComponent<SteamVR_TrackedObject>();
            leftController = SteamVR_Controller.Input((int)leftTrackedObject.index);
            leftTriggerValue = leftController.GetAxis(EVRButtonId.k_EButton_SteamVR_Trigger).x;
            leftTouchPadPos = leftController.GetAxis();
            if (getLeftMethod.Count == 0)
            {
                getLeftMethod = new List<GetMethod>();
                getLeftMethod.Add(leftController.GetTouchDown);
                getLeftMethod.Add(leftController.GetTouch);
                getLeftMethod.Add(leftController.GetTouchUp);
                getLeftMethod.Add(leftController.GetPressDown);
                getLeftMethod.Add(leftController.GetPress);
                getLeftMethod.Add(leftController.GetPressUp);
            }
        }
        else
        {
            isLeftTracked = false;
            leftTrackedObj = GameObject.Find(leftControllerName);
        }

        foreach (ButtonMask key in Enum.GetValues(typeof(ButtonMask)))
        {
            ulong buttonMask = ConvertKey(key);
            if (isRightTracked)
            {
                string keyString;
                foreach (GetMethod method in getRightMethod)
                {
                    keyString = method.Method.Name + key.ToString();
                    if (method(buttonMask))
                    {
                        rightKeyTable.Add(keyString, true);
                    }
                    else
                    {
                        rightKeyTable.Add(keyString, false);
                    }
                }
            }
            if (isLeftTracked)
            {
                string keyString;
                foreach (GetMethod method in getLeftMethod)
                {
                    keyString = method.Method.Name + key.ToString();
                    if (method(buttonMask))
                    {
                        leftkeyTable.Add(keyString, true);
                    }
                    else
                    {
                        leftkeyTable.Add(keyString, false);
                    }
                }
            }
        }
    }
}
