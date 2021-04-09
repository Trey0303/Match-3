using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matched : MonoBehaviour
{
    //public PlayerController board;

    //public bool isMatched = false;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    board = GameObject.Find("Board").GetComponent<PlayerController>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    FindMatches();
    //    if (isMatched){
    //        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
    //        mySprite.color = new Color(0f, 0f, 0f, .2f);
    //    }
    //}

    ////check for shape matches
    //void FindMatches()
    //{
    //    if (col >= 1 && col < board.width - 1)
    //    {
    //        GameObject leftShapeOne = board.allShapes[col - 1, row];
    //        GameObject rightShapeOne = board.allShapes[col + 1, row];
    //        if (leftShapeOne.tag == this.gameObject.tag && rightShapeOne.tag == this.gameObject.tag)
    //        {
    //            leftShapeOne.GetComponent<Matched>().isMatched = true;
    //            rightShapeOne.GetComponent<Matched>().isMatched = true;
    //            isMatched = true;
    //        }
    //    }
    //}
}
