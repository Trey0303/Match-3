using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCheck : MonoBehaviour
{
    public Board board;

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("Board").GetComponent<Board>();
    }

    public void FindAllMatches()
    {
        StartCoroutine(FindMatches());
    }

    private IEnumerator FindMatches()//checks for matching shapes
    {
        yield return new WaitForSeconds(.1f);
        for(int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                GameObject curShape = board.allShapes[i, j];
                if(curShape != null)
                {
                    if(i >= 1 && i < board.width - 1)//checks horizontally
                    {
                        GameObject leftShape = board.allShapes[i - 1, j];
                        GameObject rightShape = board.allShapes[i + 1, j];
                        if(leftShape != null && rightShape != null)
                        {
                            if(leftShape.tag == curShape.tag && rightShape.tag == curShape.tag)
                            {
                                leftShape.GetComponent<PlayerController>().isMatched = true;
                                rightShape.GetComponent<PlayerController>().isMatched = true;
                                curShape.GetComponent<PlayerController>().isMatched = true;
                            }
                        }
                    }

                    if (j >= 1 && j < board.height - 1)//checks vertically
                    {
                        GameObject upShape = board.allShapes[i , j + 1];
                        GameObject downShape = board.allShapes[i , j - 1];
                        if (upShape != null && downShape != null)
                        {
                            if (upShape.tag == curShape.tag && downShape.tag == curShape.tag)
                            {
                                upShape.GetComponent<PlayerController>().isMatched = true;
                                downShape.GetComponent<PlayerController>().isMatched = true;
                                curShape.GetComponent<PlayerController>().isMatched = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
