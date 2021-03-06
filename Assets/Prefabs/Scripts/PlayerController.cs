using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int col;
    public int row;

    //used to actually move the shapes
    public int targetX;
    public int targetY;

    public bool isMatched = false;

    private MatchCheck checkforMatches;

    public Board board;//reference Board script
    private GameObject otherShape;//points to shape that needs to change with current shape

    private Vector2 startMouseHoldPos;//holds start position of mouse click
    private Vector2 endMouseHoldPos;//holds end position of mouse click
    private Vector2 tempPosition;//holds the position that target should move to

    public float dragAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("Board").GetComponent<Board>();//finds an object named "Board" and grabs its script to use
        checkforMatches = GameObject.Find("MatchFinder").GetComponent<MatchCheck>();
        //cast my transform position as int because my targetX/Y and row/col are int
        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
        col = targetX;//sets col to start equal targetX position
        row = targetY;//sets col to start to equal targetY position
    }

    // Update is called once per frame
    void Update()
    {

        //this just changes the color of any matching shapes
        if (isMatched)
        {
            //colors out matching shapes
            SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
            mySprite.color = new Color(0f, 0f, 0f, .2f);
            //destroys matching shapes

        }

        targetX = col;//takes any changes made to the col position and applies to targetX as well
        targetY = row;//takes any changes made to the row position and applies to targetY as well
        //moves horizontally
        if (Mathf.Abs(targetX - transform.position.x) > .1)//if not at targetX position
        {
            //moving towards target position
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);//moves towards the target position

            checkforMatches.FindAllMatches();//checks for any matches
        }
        else
        {
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = tempPosition;
            board.allShapes[col, row] = this.gameObject;//saves updates position on grid
        }
        //moves vertically
        if (Mathf.Abs(targetY - transform.position.y) > .1)//if not at targetY position
        {
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);//moves towards the target position
            
            checkforMatches.FindAllMatches();//checks for any matches
        }
        else
        {
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = tempPosition;
            board.allShapes[col, row] = this.gameObject;
            
        }
    }

    private void OnMouseDown()//when clicked
    {
        var tempMousePosition = Input.mousePosition;//get start positon
        tempMousePosition.z = 10;//set z position
        startMouseHoldPos = Camera.main.ScreenToWorldPoint(tempMousePosition);//give start position to startMouseHoldPos
        //Debug.Log(startMouseHoldPos);
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
        //Debug.Log(dragAngle);
    }

    void MoveShape()
    {
        // if player drags to the right and col is < the last col(max board width)
        if (dragAngle > -45 && dragAngle <= 45 && col < board.width - 1/*need to subtract 1 to keep inbounds of grid*/)//right
        {
            //Debug.Log("right");
            otherShape = board.allShapes[col + 1, row];//grabs the shape one col after current shape
            otherShape.GetComponent<PlayerController>().col -= 1;//make otherShape move one col back
            col += 1;//changes the targetX/y position as well
        }
        else if (dragAngle > 45 && dragAngle <= 135 && row < board.height - 1)//up
        {
            //Debug.Log("up");
            otherShape = board.allShapes[col, row + 1];//grabs the shape one row above current shape
            otherShape.GetComponent<PlayerController>().row -= 1;//make otherShape move one col forward
            row += 1;//changes the targetX/y position as well
        }
        else if ((dragAngle > 135 || dragAngle <= -135) && col >= 1)//left
        {
            //Debug.Log("left");
            otherShape = board.allShapes[col - 1, row];//grabs the shape one col before current shape
            otherShape.GetComponent<PlayerController>().col += 1;//make otherShape move one col forward
            col -= 1;//changes the targetX/y position as well
        }
        else if (dragAngle < -45 && dragAngle >= -135 && row >= 1)//down
        {
            //Debug.Log("down");
            otherShape = board.allShapes[col, row - 1];//grabs the shape one row below current shape
            otherShape.GetComponent<PlayerController>().row += 1;//make otherShape move one col foward
            row -= 1;//changes the targetX/y position as well
        }

        board.DestroyMatch();//check for shapes to delete
    }
}