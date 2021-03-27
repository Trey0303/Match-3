using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 startMouseHoldPos;
    private Vector2 endMouseHoldPos;

    public float dragAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        var tempMousePosition = Input.mousePosition;
        tempMousePosition.z = 10;
        startMouseHoldPos = Camera.main.ScreenToWorldPoint(tempMousePosition);
        Debug.Log(startMouseHoldPos);
    }

    private void OnMouseUp()
    {
        var tempMousePosition = Input.mousePosition;
        tempMousePosition.z = 10;
        endMouseHoldPos = Camera.main.ScreenToWorldPoint(tempMousePosition);
        CalculateDragAngle();//calculate angle after player lets go of mouse click
    }

    void CalculateDragAngle()
    {
        dragAngle = Mathf.Atan2(endMouseHoldPos.y - startMouseHoldPos.y, endMouseHoldPos.x - startMouseHoldPos.x) * 180 / Mathf.PI;
        Debug.Log(dragAngle);
    }
}