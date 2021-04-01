using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int col;
    public int row;
    public Board board;//reference Board script
    private GameObject otherShape;

    private Vector2 startMouseHoldPos;
    private Vector2 endMouseHoldPos;

    public float dragAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()//when clicked
    {
        var tempMousePosition = Input.mousePosition;//get start positon
        tempMousePosition.z = 10;//set z position
        startMouseHoldPos = Camera.main.ScreenToWorldPoint(tempMousePosition);//give start position to startMouseHoldPos
        Debug.Log(startMouseHoldPos);
    }

    private void OnMouseUp()//when player lets go of mouse click
    {
        var tempMousePosition = Input.mousePosition;//get end position
        tempMousePosition.z = 10;//set z position
        endMouseHoldPos = Camera.main.ScreenToWorldPoint(tempMousePosition);//give end position to endMouseHoldPos
        CalculateDragAngle();//calculate angle after player lets go of mouse click

        MoveShape();
    }

    void CalculateDragAngle()//gets distance from OnMouseDown() position to OnMouseUp() position
    {
        dragAngle = Mathf.Atan2(endMouseHoldPos.y - startMouseHoldPos.y, endMouseHoldPos.x - startMouseHoldPos.x) * 180 / Mathf.PI;
        Debug.Log(dragAngle);
    }

    void MoveShape()
    {
        if(dragAngle > -45 && dragAngle <= 45)
        {
            Debug.Log("right");
            //otherShape = Board.allShapes[];
        }
    }
}