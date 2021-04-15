using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCheck : MonoBehaviour
{
    public Board board;
    public List<GameObject> curMatches = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        board = GameObject.Find("Board").GetComponent<Board>();
    }

    private IEnumerator FindMatches()
    {
        yield return new WaitForSeconds(.2f);
        for(int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                GameObject currentShape
                if(curMatches != null)
                {
                    if(i <= 1 && i < board.width - 1)
                    {
                        GameObject leftShape = board.allShapes[i - 1, j];
                        GameObject rightShape = board.allShapes[i + 1, j];
                        if(leftShape != null && rightShape != null)
                        {
                            if(leftShape.tag == this.gameObject.tag && rightShape.tag == this.gameObject.tag)
                            {

                            }
                        }
                    }
                }
            }
        }
    }
}
