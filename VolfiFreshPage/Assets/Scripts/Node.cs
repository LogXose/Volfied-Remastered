using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour 
{
    public enum _nodeState
    {
        walkable,
        danger,
        permanent,//char walked by space on this dot while it is danger, so it has turned permanent.
        space,
        dead
    }
    public enum _childType
    {
        right,
        down,
        no
    }
    public _childType childType = _childType.no;
    public GameObject boarder;
    public _nodeState state = _nodeState.dead;
    public GameObject[,] dotObjects;
    public int sizeOfMap;
    public int xx;
    public int yy;
    public bool pointersAssigned = false;
    private int counter = 0;
    public bool breakpoint = false;

    private void Update()
    {
        if (!pointersAssigned)
        {
            dotObjects = boarder.GetComponent<Boarder>().dotObjects;
            switch (state)
            {
                case _nodeState.walkable:
                    if (yy - 1 >= 0)
                    {
                        if (dotObjects[xx, yy - 1].GetComponent<Node>().state == _nodeState.walkable)
                        {
                            transform.GetChild(1).gameObject.SetActive(true);
                            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                            setChildType(_childType.down);
                        }
                        else if (dotObjects[xx, yy - 1].GetComponent<Node>().state == _nodeState.permanent)
                        {
                            transform.GetChild(1).gameObject.SetActive(true);
                            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                            setChildType(_childType.down);
                        }
                    }
                    if (xx + 1 <= sizeOfMap)
                    {
                        if (dotObjects[xx + 1, yy].GetComponent<Node>().state == _nodeState.walkable)
                        {
                            transform.GetChild(0).gameObject.SetActive(true);
                            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                            setChildType(_childType.right);
                        }
                        else if (dotObjects[xx + 1, yy].GetComponent<Node>().state == _nodeState.permanent)
                        {
                            transform.GetChild(0).gameObject.SetActive(true);
                            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                            setChildType(_childType.right);
                        }
                    }
                    break;
                case _nodeState.danger:
                    break;
                case _nodeState.permanent:
                    if (yy - 1 >= 0)
                    {
                        if (dotObjects[xx, yy - 1].GetComponent<Node>().state == _nodeState.walkable)
                        {
                            transform.GetChild(1).gameObject.SetActive(true);
                            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                            setChildType(_childType.down);
                        }
                        else if (dotObjects[xx, yy - 1].GetComponent<Node>().state == _nodeState.permanent)
                        {
                            transform.GetChild(1).gameObject.SetActive(true);
                            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                            setChildType(_childType.down);
                        }
                    }
                    if (xx + 1 <= sizeOfMap)
                    {
                        if (dotObjects[xx + 1, yy].GetComponent<Node>().state == _nodeState.walkable)
                        {
                            transform.GetChild(0).gameObject.SetActive(true);
                            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.red; 
                            setChildType(_childType.right);
                        }
                        else if (dotObjects[xx + 1, yy].GetComponent<Node>().state == _nodeState.permanent)
                        {
                            transform.GetChild(0).gameObject.SetActive(true);
                            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                            setChildType(_childType.right);
                        }
                    }
                    break;
                case _nodeState.dead:
                    break;
                default:
                    break;
            }
            pointersAssigned = true;
        }
    }

    void setChildType(_childType childType)
    {
        /*switch (childType)
        {
            case _childType.right:
                transform.GetChild(1).gameObject.SetActive(false);
                break;
            case _childType.down:
                transform.GetChild(0).gameObject.SetActive(false);
                break;
            case _childType.no:
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(0).gameObject.SetActive(false);
                break;
            default:
                break;
        }*/
    }
}
