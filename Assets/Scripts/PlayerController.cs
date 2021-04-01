using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Board
{
    public int col;
    public int row;

    public int targetX;
    public int targetY;

    public static Board board;//reference Board script
    private GameObject otherShape;

    private Vector2 startMouseHoldPos;
    private Vector2 endMouseHoldPos;

    public float dragAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
        col = targetX;
        row = targetY;
    }

    // Update is called once per frame
    void Update()
    {
        targetX = col;
        targetY = row;
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
        if (dragAngle > -45 && dragAngle <= 45 /*&& /*col < board.width*/)//right
        {
            Debug.Log("right");
            otherShape = allShapes[col + 1, row];//otherShape is the shape on the next col right of current col
            otherShape.GetComponent<PlayerController>().col -= 1;//make otherShape move one col back
            col += 1;//place current shape moves one col over
        }
        else if (dragAngle > 45 && dragAngle <= 135 /*&& row < board.height*/)//up
        {
            Debug.Log("up");
            otherShape = allShapes[col, row + 1];//otherShape is the shape on the next col right of current col
            otherShape.GetComponent<PlayerController>().row -= 1;//make otherShape move one col back
            row += 1;//place current shape moves one col over
        }
        else if ((dragAngle > 135 || dragAngle <= -135) /*&& col >= 1*/)//left
        {
            Debug.Log("left");
            otherShape = allShapes[col + 1, row];//otherShape is the shape on the next col right of current col
            otherShape.GetComponent<PlayerController>().col += 1;//make otherShape move one col back
            col -= 1;//place current shape moves one col over
        }
        else if (dragAngle > -45 && dragAngle <= -135 /*&& row >= 1*/)//down
        {
            Debug.Log("down");
            otherShape = allShapes[col, row - 1];//otherShape is the shape on the next col right of current col
            otherShape.GetComponent<PlayerController>().row += 1;//make otherShape move one col back
            row -= 1;//place current shape moves one col over
        }
    }
}