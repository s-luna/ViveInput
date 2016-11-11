using UnityEngine;
using System.Collections;

public class InputSample : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {

        if (ViveInput.GetTouchDown(Controller.Right, ButtonMask.Trigger))
        {
            Debug.Log("右コントローラのトリガーを浅く引いた");
        }
        if (ViveInput.GetPressDown(Controller.Right, ButtonMask.Trigger))
        {
            Debug.Log("右コントローラのトリガーを深く引いた");
        }
        if (ViveInput.GetTouchUp(Controller.Right, ButtonMask.Trigger))
        {
            Debug.Log("右コントローラのトリガーを離した");
        }
        if (ViveInput.GetPressDown(Controller.Right, ButtonMask.Touchpad))
        {
            Debug.Log("右コントローラのタッチパッドをクリックした");
        }
        if (ViveInput.GetPress(Controller.Right, ButtonMask.Touchpad))
        {
            Debug.Log("右コントローラのタッチパッドをクリックしている");
        }
        if (ViveInput.GetPressUp(Controller.Right, ButtonMask.Touchpad))
        {
            Debug.Log("右コントローラのタッチパッドをクリックして離した");
        }
        if (ViveInput.GetTouchDown(Controller.Right, ButtonMask.Touchpad))
        {
            Debug.Log("右コントローラのタッチパッドに触った");
        }
        if (ViveInput.GetTouchUp(Controller.Right, ButtonMask.Touchpad))
        {
            Debug.Log("右コントローラのタッチパッドを離した");
        }
        if (ViveInput.GetPressDown(Controller.Right, ButtonMask.ApplicationMenu))
        {
            Debug.Log("右コントローラのメニューボタンをクリックした");
        }
        if (ViveInput.GetPressDown(Controller.Right, ButtonMask.Grip))
        {
            Debug.Log("右コントローラのグリップボタンをクリックした");
        }

        if (ViveInput.GetTouch(Controller.Right, ButtonMask.Trigger))
        {
            Debug.Log("右コントローラのトリガーを浅く引いている");
        }
        if (ViveInput.GetPress(Controller.Right, ButtonMask.Trigger))
        {
            Debug.Log("右コントローラのトリガーを深く引いている");
        }
        if (ViveInput.GetTouch(Controller.Right, ButtonMask.Touchpad))
        {
            Debug.Log("右コントローラのタッチパッドに触っている");
        }


        if (ViveInput.GetTouchDown(Controller.Left, ButtonMask.Trigger))
        {
            Debug.Log("左コントローラのトリガーを浅く引いた");
        }
        if (ViveInput.GetPressDown(Controller.Left, ButtonMask.Trigger))
        {
            Debug.Log("左コントローラのトリガーを深く引いた");
        }
        if (ViveInput.GetTouchUp(Controller.Left, ButtonMask.Trigger))
        {
            Debug.Log("左コントローラのトリガーを離した");
        }
        if (ViveInput.GetPressDown(Controller.Left, ButtonMask.Touchpad))
        {
            Debug.Log("左コントローラのタッチパッドをクリックした");
        }
        if (ViveInput.GetPress(Controller.Left, ButtonMask.Touchpad))
        {
            Debug.Log("左コントローラのタッチパッドをクリックしている");
        }
        if (ViveInput.GetPressUp(Controller.Left, ButtonMask.Touchpad))
        {
            Debug.Log("左コントローラのタッチパッドをクリックして離した");
        }
        if (ViveInput.GetTouchDown(Controller.Left, ButtonMask.Touchpad))
        {
            Debug.Log("左コントローラのタッチパッドに触った");
        }
        if (ViveInput.GetTouchUp(Controller.Left, ButtonMask.Touchpad))
        {
            Debug.Log("左コントローラのタッチパッドを離した");
        }
        if (ViveInput.GetPressDown(Controller.Left, ButtonMask.ApplicationMenu))
        {
            Debug.Log("左コントローラのメニューボタンをクリックした");
        }
        if (ViveInput.GetPressDown(Controller.Left, ButtonMask.Grip))
        {
            Debug.Log("左コントローラのグリップボタンをクリックした");
        }

        if (ViveInput.GetTouch(Controller.Left, ButtonMask.Trigger))
        {
            Debug.Log("左コントローラのトリガーを浅く引いている");
        }
        if (ViveInput.GetPress(Controller.Left, ButtonMask.Trigger))
        {
            Debug.Log("左コントローラのトリガーを深く引いている");
        }
        if (ViveInput.GetTouch(Controller.Left, ButtonMask.Touchpad))
        {
            Debug.Log("左コントローラのタッチパッドに触っている");
        }

        //Debug.Log(ViveInput.GetTriggerValue(Controller.Right));
        //Debug.Log(ViveInput.GetTouchPos(Controller.Right));

    }
}
