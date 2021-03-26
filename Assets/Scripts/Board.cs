using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //initialize height and width of game board
    public int width;
    public int height;
    public GameObject tilePiece;
    public GameObject[] shapes;
    private BackBoard[,] allTiles;//creates empty 2D array
    private GameObject[,] allShapes;//to store all shapes on grid

    // Start is called before the first frame update
    void Start()
    {
        //sets boards height and width(how big the board needs to be)
        allTiles = new BackBoard[width, height];//gives allPieces its height and width
        allShapes = new GameObject[width, height];//gives allshapes its max height and width

        //Sets up board
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //spawn board tiles
                Vector2 curPosition = new Vector2(i, j);//gets current grid position
                GameObject newTile = Instantiate(tilePiece, curPosition, Quaternion.identity);//create new tile at current position
                newTile.transform.parent = this.transform;
                newTile.name = string.Format("{0}, {1}", i, j);//name tile on graph

                int redos = 0;

                int shapeToUse = Random.Range(0, shapes.Length);
                while (MatchesAt(i, j, shapes[shapeToUse]))//while there are still matches when loading board
                {
                    shapeToUse = Random.Range(0, shapes.Length);//try randomly picking a different shape
                    redos++;
                }
                Debug.Log(redos);
                redos = 0;
                //spawn shapes randomly
                GameObject shape = Instantiate(shapes[shapeToUse], curPosition, Quaternion.identity);
                shape.transform.parent = this.transform;
                shape.name = string.Format("{0}, {1}", i, j);
                allShapes[i, j] = shape;//store current shape in array
            }
        }
    }

    private bool MatchesAt(int col, int row, GameObject piece)
    {
        if(col > 1 && row > 1)//checks at cols and rows 2 and above for matches
        {
            //checks if tags for pieces 2 to current piece for the same tag
            if (allShapes[col - 1, row].tag == piece.tag && allShapes[col - 2, row].tag == piece.tag)
            {
                return true;
            }
            //checks if tags for pieces 2 to current piece for the same tag
            if (allShapes[col, row - 1].tag == piece.tag && allShapes[col, row - 2].tag == piece.tag)
            {
                return true;
            }
        }
        else if (col <= 1 || row <= 1)//check if the first row or column for matches
        {
            if(row > 1)//if col <= 1 is the case
            {

                if(allShapes[col, row - 1].tag == piece.tag && allShapes[col, row - 2].tag == piece.tag)//check the two shapes behind
                {
                    return true;
                }
            }
            if (col > 1)//if row <= 1 is the case
            {
                if (allShapes[col - 1, row].tag == piece.tag && allShapes[col - 2, row].tag == piece.tag)//check the two shapes below
                {
                    return true;
                }
            }
        }
        
        return false;
    }

}
