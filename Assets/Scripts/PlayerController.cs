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
        startMouseHoldPos = Input.mousePosition;
        Debug.Log(startMouseHoldPos);
    }
}