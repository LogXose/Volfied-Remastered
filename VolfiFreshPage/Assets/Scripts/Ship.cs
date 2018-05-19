using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {
	public float speed = 1,zz = -5;
    public GameObject board;
    GameObject[,] dotObjects;
    Vector3[,] dotVectors;
    public int xx = 0;
    public int yy = 0;
    public int TextureBorder;
    public Material deadZone;
    bool checking = false;
    private void Start()
    {
        dotObjects = board.GetComponent<Boarder>().dotObjects;
        dotVectors = board.GetComponent<Boarder>().dotVectors;
        TextureBorder = board.GetComponent<Boarder>().textureBorderX;
        transform.position = dotVectors[0, 0];
    }
    private void Update()
    {
        if(!checking)
        MovementControl();

    }

    void MovementControl()
    {
        #region dangerPath
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (yy + 1 <= TextureBorder
                    && dotObjects[xx, yy + 1].GetComponent<Node>().state == Node._nodeState.walkable)
                {
                    transform.position += Vector3.up * speed;
                    dotObjects[xx, yy + 1].GetComponent<Node>().pointersAssigned = false;
                    if (dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.permanent)
                    {
                        dotObjects[xx, yy + 1].GetComponent<Node>().breakpoint = true;
                        reDraw(xx, yy + 1);
                    }
                    yy++;
                }
                else if (yy + 1 <= TextureBorder
                    && dotObjects[xx, yy + 1].GetComponent<Node>().state == Node._nodeState.dead)
                {
                    if (yy + 2 <= TextureBorder)
                    {
                        if (dotObjects[xx, yy + 2].GetComponent<Node>().state == Node._nodeState.permanent &&
dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.permanent)
                        {
                            return;
                        }
                    }
                    transform.position += Vector3.up * speed;
                    dotObjects[xx, yy + 1].GetComponent<Node>().pointersAssigned = false;
                    dotObjects[xx, yy].GetComponent<Node>().pointersAssigned = false;
                    if (dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.walkable)
                    {
                        dotObjects[xx, yy].GetComponent<Node>().breakpoint = true;
                    }
                    dotObjects[xx, yy + 1].GetComponent<Node>().state = Node._nodeState.permanent;
                    yy++;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (yy - 1 >= 0
                    && dotObjects[xx, yy - 1].GetComponent<Node>().state == Node._nodeState.walkable)
                {
                    transform.position += Vector3.down * speed;
                    dotObjects[xx, yy - 1].GetComponent<Node>().pointersAssigned = false;
                    if (dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.permanent)
                    {
                        dotObjects[xx, yy - 1].GetComponent<Node>().breakpoint = true;
                        reDraw(xx, yy - 1);
                    }
                    yy--;
                }
                else if (yy - 1 >= 0
                   && dotObjects[xx, yy - 1].GetComponent<Node>().state == Node._nodeState.dead)
                {
                    if (yy - 2 >= 0)
                    {
                        if (dotObjects[xx, yy - 2].GetComponent<Node>().state == Node._nodeState.permanent &&
dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.permanent)
                        {
                            return;
                        }
                    }
                    transform.position += Vector3.down * speed;
                    dotObjects[xx, yy - 1].GetComponent<Node>().pointersAssigned = false;
                    dotObjects[xx, yy].GetComponent<Node>().pointersAssigned = false;
                    if (dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.walkable)
                    {
                        dotObjects[xx, yy].GetComponent<Node>().breakpoint = true;
                    }
                    dotObjects[xx, yy - 1].GetComponent<Node>().state = Node._nodeState.permanent;
                    yy--;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (xx - 1 >= 0
                    && dotObjects[xx - 1, yy].GetComponent<Node>().state == Node._nodeState.walkable)
                {
                    transform.position += Vector3.left * speed;
                    dotObjects[xx - 1, yy].GetComponent<Node>().pointersAssigned = false;
                    if (dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.permanent)
                    {
                        dotObjects[xx - 1, yy].GetComponent<Node>().breakpoint = true;
                        reDraw(xx - 1, yy);
                    }
                    xx--;
                }
                else if (xx - 1 >= 0
                   && dotObjects[xx - 1, yy].GetComponent<Node>().state == Node._nodeState.dead)
                {
                    if (xx - 2 >= 0)
                    {
                        if (dotObjects[xx - 2, yy].GetComponent<Node>().state == Node._nodeState.permanent &&
dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.permanent)
                        {
                            return;
                        }
                    }
                    transform.position += Vector3.left * speed;
                    dotObjects[xx - 1, yy].GetComponent<Node>().pointersAssigned = false;
                    dotObjects[xx, yy].GetComponent<Node>().pointersAssigned = false;
                    if (dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.walkable)
                    {
                        dotObjects[xx, yy].GetComponent<Node>().breakpoint = true;
                    }
                    dotObjects[xx - 1, yy].GetComponent<Node>().state = Node._nodeState.permanent;
                    xx--;
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (xx + 1 <= TextureBorder
                    && dotObjects[xx + 1, yy].GetComponent<Node>().state == Node._nodeState.walkable)
                {
                    transform.position += Vector3.right * speed;
                    dotObjects[xx + 1, yy].GetComponent<Node>().pointersAssigned = false;
                    if (dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.permanent)
                    {
                        dotObjects[xx + 1, yy].GetComponent<Node>().breakpoint = true;
                        reDraw(xx + 1, yy);
                    }
                    xx++;
                }
                else if (xx + 1 <= TextureBorder
                   && dotObjects[xx + 1, yy].GetComponent<Node>().state == Node._nodeState.dead)
                {
                    if (xx + 2 <= TextureBorder)
                    {
                        if (dotObjects[xx + 2, yy].GetComponent<Node>().state == Node._nodeState.permanent &&
    dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.permanent)
                        {
                            return;
                        }
                    }
                    transform.position += Vector3.right * speed;
                    dotObjects[xx + 1, yy].GetComponent<Node>().pointersAssigned = false;
                    dotObjects[xx, yy].GetComponent<Node>().pointersAssigned = false;
                    if (dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.walkable)
                    {
                        dotObjects[xx, yy].GetComponent<Node>().breakpoint = true;
                    }
                    dotObjects[xx + 1, yy].GetComponent<Node>().state = Node._nodeState.permanent;
                    xx++;
                }
            }
        }
        #endregion
        else if (dotObjects[xx, yy].GetComponent<Node>().state == Node._nodeState.walkable)
        {
            #region casualPath
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (yy + 1 <= TextureBorder
                    && dotObjects[xx, yy + 1].GetComponent<Node>().state == Node._nodeState.walkable)
                {
                    transform.position += Vector3.up * speed;
                    dotObjects[xx, yy + 1].GetComponent<Node>().pointersAssigned = false;
                    yy++;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (yy - 1 >= 0
                    && dotObjects[xx, yy - 1].GetComponent<Node>().state == Node._nodeState.walkable)
                {
                    transform.position += Vector3.down * speed;
                    dotObjects[xx, yy - 1].GetComponent<Node>().pointersAssigned = false;
                    yy--;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (xx - 1 >= 0
                    && dotObjects[xx - 1, yy].GetComponent<Node>().state == Node._nodeState.walkable)
                {
                    transform.position += Vector3.left * speed;
                    dotObjects[xx - 1, yy].GetComponent<Node>().pointersAssigned = false;
                    xx--;
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (xx + 1 <= TextureBorder
                    && dotObjects[xx + 1, yy].GetComponent<Node>().state == Node._nodeState.walkable)
                {
                    transform.position += Vector3.right * speed;
                    dotObjects[xx + 1, yy].GetComponent<Node>().pointersAssigned = false;
                    xx++;
                }
            }
            #endregion
        }
    }

    /// <summary>
    /// alan kazanildiginda kazanilan alaninin taranmasi ve tekrar sahaya girilebilir hale getirilmesi ayrica win check
    /// </summary>
    void reDraw(int xPos,int yPos)
    {
        checking = true;
        GameObject[] line1 = new GameObject[(int)Mathf.Pow((float)TextureBorder, 2)];
        GameObject[] line2 = new GameObject[(int)Mathf.Pow((float)TextureBorder, 2)];
        bool line1Done = false;
        int xL1 = xPos;
        int xL2 = xPos;
        int yL1 = yPos;
        int yL2 = yPos;
        bool line2Done = false;
        int increament1 = 0;
        int increament2 = 0;
        #region walkable
        while (!line1Done)
        {
            GameObject nextObject = NextOne(Node._nodeState.walkable, xL1, yL1,out xL1,out yL1);
            if(nextObject == null)
            {
                line1Done = true;
                goto line1result;
            }
            line1[increament1] = nextObject;
        }
        line1result:
        while (!line2Done)
        {
            GameObject nextObject = NextOne(Node._nodeState.walkable, xL2, yL2, out xL2, out yL2);

            if (nextObject == null)
            {
                line2Done = true;
                goto result2;
            }
            line2[increament2] = nextObject;
        }
        result2:
        #endregion
        #region deadHunt

        //dead hunt
        GameObject[] basket1 = new GameObject[(int)Mathf.Pow((float)TextureBorder, 2)];
        GameObject[] basket2 = new GameObject[(int)Mathf.Pow((float)TextureBorder, 2)];
        bool enemyDetected1 = false;
        bool enemyDetected2 = false;
        int inc1 = -1;
        int inc2 = -1;
        bool firstDone = false;
        bool secondDone = false;
        foreach (GameObject dot in line1)
        {
            Node node = dot.GetComponent<Node>();
            int xxx = node.xx;
            int yyy = node.yy;
            GameObject nextOne = NextOne(Node._nodeState.dead, xxx, yyy, out xxx, out yyy,out enemyDetected1);
            if (nextOne != null)
            {
                Debug.Log("yes");
            }
            while (!firstDone)
            {
                if (nextOne == null)
                {
                    firstDone = true;
                    continue;
                }
                inc1++;
                Debug.Log(inc1);
                basket1[inc1] = nextOne;
            }
            firstDone = false;
        }
        foreach (GameObject dot in line2)
        {
            Node node = dot.GetComponent<Node>();
            int xxx = node.xx;
            int yyy = node.yy;
            GameObject nextOne = NextOne(Node._nodeState.dead, xxx, yyy, out xxx, out yyy, out enemyDetected2);
            while (!secondDone)
            {
                if (nextOne == null)
                {
                    secondDone = true;
                    continue;
                }
                inc2++;
                basket2[inc2] = nextOne;
            }
            secondDone = false;
        }
        Debug.Log("3");
        foreach (GameObject dot in basket1)
        {
            GameObject mesh = dot.GetComponent<Node>().mesh;
            Destroy(mesh);
        }
        foreach(GameObject dot in dotObjects)
        {
            dot.GetComponent<Node>().refresh = true;
        }
        #endregion
        checking = false;
    }

    private GameObject NextOne(Node._nodeState checkState, int xxx, int yyy,out int xSave,out int ySave)
    {
        if (xxx + 1 <= TextureBorder)
        {
            if (dotObjects[xxx + 1, yyy].GetComponent<Node>().state == checkState && !dotObjects[xxx + 1, yyy].GetComponent<Node>().drawCheck
                     && !dotObjects[xxx + 1, yyy].GetComponent<Node>().breakpoint)
            {
                dotObjects[xxx + 1, yyy].GetComponent<Node>().drawCheck = true;
                xSave = xxx + 1;
                ySave = yyy;
                return dotObjects[xxx + 1, yyy];
            }
        }
        if (xxx - 1 >= 0)
        {
            if (dotObjects[xxx - 1, yyy].GetComponent<Node>().state == checkState && !dotObjects[xxx - 1, yyy].GetComponent<Node>().drawCheck
                    && !dotObjects[xxx - 1, yyy].GetComponent<Node>().breakpoint)
            {
                dotObjects[xxx - 1, yyy].GetComponent<Node>().drawCheck = true;
                xSave = xxx - 1;
                ySave = yyy;
                return dotObjects[xxx - 1, yyy];
            }
        }
        if (yyy + 1 <= TextureBorder)
        {
            if (dotObjects[xxx, yyy + 1].GetComponent<Node>().state == checkState && !dotObjects[xxx, yyy + 1].GetComponent<Node>().drawCheck
            && !dotObjects[xxx, yyy + 1].GetComponent<Node>().breakpoint)
            {
                dotObjects[xxx, yyy + 1].GetComponent<Node>().drawCheck = true;
                xSave = xxx;
                ySave = yyy + 1;
                return dotObjects[xxx, yyy + 1];
            }
        }
        if (yyy - 1 >= 0)
        {
            if (dotObjects[xxx, yyy - 1].GetComponent<Node>().state == checkState
            && !dotObjects[xxx, yyy - 1].GetComponent<Node>().drawCheck)
            {
                dotObjects[xxx, yyy - 1].GetComponent<Node>().drawCheck = true;
                xSave = xxx;
                ySave = yyy - 1;
                return dotObjects[xxx, yyy - 1];
            }
        }
        xSave = -1;
        ySave = -1;
        return null;
    }
    private GameObject NextOne(Node._nodeState state, int xxx, int yyy, out int xSave, out int ySave,out bool enemyDetected)
    {
        if (xxx + 1 <= TextureBorder)
        {
            if (dotObjects[xxx + 1, yyy].GetComponent<Node>().state == state && !dotObjects[xxx + 1, yyy].GetComponent<Node>().drawCheck
            && !dotObjects[xxx + 1, yyy].GetComponent<Node>().breakpoint)
            {
                dotObjects[xxx + 1, yyy].GetComponent<Node>().drawCheck = true;
                xSave = xxx + 1;
                ySave = yyy;
                if (dotObjects[xxx + 1, yyy].GetComponent<Node>().enemyOnIt)
                {
                    enemyDetected = true;
                }
                else
                {
                    enemyDetected = false;
                }
                return dotObjects[xxx + 1, yyy];
            }
        }
        if (xxx - 1 >= 0)
        {
            if (dotObjects[xxx - 1, yyy].GetComponent<Node>().state == state && !dotObjects[xxx - 1, yyy].GetComponent<Node>().drawCheck
           && !dotObjects[xxx - 1, yyy].GetComponent<Node>().breakpoint)
            {
                dotObjects[xxx - 1, yyy].GetComponent<Node>().drawCheck = true;
                xSave = xxx - 1;
                ySave = yyy;
                if (dotObjects[xxx - 1, yyy].GetComponent<Node>().enemyOnIt)
                {
                    enemyDetected = true;
                }
                else
                {
                    enemyDetected = false;
                }
                return dotObjects[xxx - 1, yyy];
            }
        }
        if (yyy + 1 <= TextureBorder)
        {
            if (dotObjects[xxx, yyy + 1].GetComponent<Node>().state == state && !dotObjects[xxx, yyy + 1].GetComponent<Node>().drawCheck
            && !dotObjects[xxx, yyy + 1].GetComponent<Node>().breakpoint)
            {
                dotObjects[xxx, yyy + 1].GetComponent<Node>().drawCheck = true;
                xSave = xxx;
                ySave = yyy + 1;
                if (dotObjects[xxx, yyy + 1].GetComponent<Node>().enemyOnIt)
                {
                    enemyDetected = true;
                }
                else
                {
                    enemyDetected = false;
                }
                return dotObjects[xxx, yyy + 1];
            }
        }
        if (yyy - 1 >= 0)
        {
            if (dotObjects[xxx, yyy - 1].GetComponent<Node>().state == state
            && !dotObjects[xxx, yyy - 1].GetComponent<Node>().drawCheck)
            {
                dotObjects[xxx, yyy - 1].GetComponent<Node>().drawCheck = true;
                xSave = xxx;
                ySave = yyy - 1;
                if (dotObjects[xxx, yyy - 1].GetComponent<Node>().enemyOnIt)
                {
                    enemyDetected = true;
                }
                else
                {
                    enemyDetected = false;
                }
                return dotObjects[xxx, yyy - 1];
            }
        }
        xSave = xxx;
        ySave = yyy;
        enemyDetected = false;
        return null;
    }
}
