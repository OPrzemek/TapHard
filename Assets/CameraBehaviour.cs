using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraBehaviour : MonoBehaviour
{

    const float epsilon = 0.0001f;
    static bool approximatelyEquals(float a1, float a2)
    {
        float d = Mathf.Abs(a1 - a2);
        return d < epsilon;
    }
    static Vector3 lastAngle = new Vector3();
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t <= 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.rotation = toAngle;
    }

    private Vector2 lastPosition;

    void Update()
    {
        //if (Input.touchCount == 1)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.phase == UnityEngine.TouchPhase.Began)
        //    {
        //        lastPosition = touch.position;
        //    }
        //    if (touch.phase == UnityEngine.TouchPhase.Moved)
        //    {
        //        // get the moved direction compared to the initial touch position
        //        var direction = touch.position - lastPosition;

        //        // get the signed x direction
        //        // if(direction.x >= 0) 1 else -1
        //        var signedDirection = Mathf.Sign(direction.x);

        //        lastPosition = touch.position;
        //        Debug.Log(signedDirection);
        //    }
        //}

        lastAngle = transform.localEulerAngles;
        if(approximatelyEquals(transform.localEulerAngles.y, 0.0f) 
            || approximatelyEquals(transform.localEulerAngles.y, 90.0f) 
                || approximatelyEquals(transform.localEulerAngles.y, 180.0f)
                    || approximatelyEquals(transform.localEulerAngles.y, 270.0f))
        {
            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                StartCoroutine(RotateMe(Vector3.up * 90.0f, 0.2f));
            }
            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                StartCoroutine(RotateMe(Vector3.up * -90.0f, 0.2f));
            }
        }
    }
}
