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

    private void Start()
    {
        dotObjects = board.GetComponent<Boarder>().dotObjects;
        dotVectors = board.GetComponent<Boarder>().dotVectors;
        TextureBorder = board.GetComponent<Boarder>().textureBorderX;
        transform.position = dotVectors[0, 0];
    }
    private void Update()
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
                    if(dotObjects[xx, yy + 1].GetComponent<Node>().state == Node._nodeState.permanent)
                    {
                        dotObjects[xx, yy + 1].GetComponent<Node>().breakpoint = true;
                        reDraw();
                    }
                    yy++;
                }
                else if(yy + 1 <= TextureBorder
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
                    if(dotObjects[xx,yy].GetComponent<Node>().state == Node._nodeState.walkable)
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
                    if (dotObjects[xx, yy - 1].GetComponent<Node>().state == Node._nodeState.permanent)
                    {
                        dotObjects[xx, yy - 1].GetComponent<Node>().breakpoint = true;
                        reDraw();
                    }
                    yy--;
                }else if (yy - 1 >= 0
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
                    if (dotObjects[xx - 1, yy].GetComponent<Node>().state == Node._nodeState.permanent)
                    {
                        dotObjects[xx - 1, yy].GetComponent<Node>().breakpoint = true;
                        reDraw();
                    }
                    xx--;
                }else if (xx - 1 >= 0
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
                    if (dotObjects[xx + 1, yy].GetComponent<Node>().state == Node._nodeState.permanent)
                    {
                        dotObjects[xx + 1, yy].GetComponent<Node>().breakpoint = true;
                        reDraw();
                    }
                    xx++;
                }else if (xx + 1 <= TextureBorder
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
        else if(dotObjects[xx,yy].GetComponent<Node>().state == Node._nodeState.walkable)
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
    void reDraw()
    {
        
    }

    /*void Start(){
		transform.position = GameObject.Find ("Nokta"+noktaIndexer).transform.position;
		ekranIndex = GameObject.Find ("Boarder").GetComponent<Boarder> ().textureBorderX;
	}*/
    /*void Update(){

		//KONTROL MEKANiZMALARI
		//space'li

		//sabah bu kısmı hallet

		if (Input.GetKey (KeyCode.Space) ) {
			//dolsun buralaaaaaaaaaaaaarrrrrrrrrrrrrrrrrrrr...

			// upppp
			//indir
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (GameObject.Find ("Nokta" + (noktaIndexer + 1))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.y < GameObject.Find ("Nokta" + (noktaIndexer + 1)).transform.position.y) {						
						GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
						GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;

					}
				}
			}

			//basılı
			if (Input.GetKey(KeyCode.UpArrow) ) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
					GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
				}
				if (GameObject.Find ("Nokta" + (noktaIndexer + 1))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.y < GameObject.Find ("Nokta" + (noktaIndexer + 1)).transform.position.y) {
						GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().enable = true;
						noktaIndexer++;
					}
				}
				if (Input.GetKeyUp (KeyCode.Space)) {
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().objeninYönü = new Vector3 (0, -1);
					GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
				}
			}
			//kaldır
			if (Input.GetKeyUp(KeyCode.UpArrow)) {
				GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().objeninYönü = new Vector3 (0, -1);
				GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
				GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
			}
			//Down

			//indir

			if (Input.GetKeyDown (KeyCode.DownArrow)) {
				if (GameObject.Find ("Nokta" + (noktaIndexer - 1))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.y > GameObject.Find ("Nokta" + (noktaIndexer - 1)).transform.position.y) {						
						GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
						GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
					}
				}
			}

			//Down basılı ve space sıralı
			if (Input.GetKey (KeyCode.DownArrow)) {
				if (GameObject.Find ("Nokta" + (noktaIndexer - 1))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.y > GameObject.Find ("Nokta" + (noktaIndexer - 1)).transform.position.y) {
						GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().enable = true;
						noktaIndexer --;
					}
				}
				if (Input.GetKeyUp (KeyCode.Space)) {
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().objeninYönü = new Vector3 (0, 1);
					GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
				}
				if (Input.GetKeyDown (KeyCode.Space)) {
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
					GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
				}
			}

			//kaldır
			if (Input.GetKeyUp(KeyCode.DownArrow)) {
				GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().objeninYönü = new Vector3 (0, 1);
				GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
				GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
			}

			//LEeeeeFT

			//İndiiir
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if (GameObject.Find ("Nokta" + (noktaIndexer - ekranIndex))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.x > GameObject.Find ("Nokta" + (noktaIndexer - ekranIndex)).transform.position.x) {						
						GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
						GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
					}
				}
			}

			//basılı
			if (Input.GetKey (KeyCode.LeftArrow)) {
				if (GameObject.Find ("Nokta" + (noktaIndexer - ekranIndex))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.x > GameObject.Find ("Nokta" + (noktaIndexer - ekranIndex)).transform.position.x) {
						GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().enable = true;
						noktaIndexer -= ekranIndex;
					}
				}
				if (Input.GetKeyUp (KeyCode.Space)) {
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().objeninYönü = new Vector3 (-1,0);
					GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
				}
				if (Input.GetKeyDown (KeyCode.Space)) {
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
					GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
				}
			}

			//kaldır
			if (Input.GetKeyUp(KeyCode.LeftArrow)) {
				GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().objeninYönü = new Vector3 (-1,0);
				GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
				GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
			}

			//RIıııııiiiiiGHT

			//indir
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if (GameObject.Find ("Nokta" + (noktaIndexer + ekranIndex))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.x < GameObject.Find ("Nokta" + (noktaIndexer + ekranIndex)).transform.position.x) {						
						Debug.Log ("ilk nokta düzgün");
						GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
						GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
					}
				}
			}

			//basılı
			if (Input.GetKey (KeyCode.RightArrow)) {
				if (GameObject.Find ("Nokta" + (noktaIndexer + ekranIndex))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.x < GameObject.Find ("Nokta" + (noktaIndexer + ekranIndex)).transform.position.x) {
						GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().enable = true;
						noktaIndexer += ekranIndex;
					}
				}
				if (Input.GetKeyUp (KeyCode.Space)) {
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().objeninYönü = new Vector3 (1,0);
					GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
				}
				if (Input.GetKeyDown (KeyCode.Space)) {
					GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
					GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
				}
			}

			//kaldır
			if (Input.GetKeyUp(KeyCode.RightArrow)) {
				GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().objeninYönü = new Vector3 (1,0);
				GameObject.Find ("Nokta" + (noktaIndexer )).GetComponent<Node> ().Changed = true;
				GameObject.Find ("Nokta" + (noktaIndexer)).GetComponent<Node> ().BreakPoint = true;
			}
		}
		//space'siz



		else {
			if (Input.GetKey (KeyCode.UpArrow)) {
				if (GameObject.Find ("Nokta" + (noktaIndexer + 1))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.y < GameObject.Find ("Nokta" + (noktaIndexer + 1)).transform.position.y) {
						if (GameObject.Find ("Nokta" + (noktaIndexer + 1)).GetComponent<Node> ().enable) {
							noktaIndexer++;
							Debug.Log ("spacesiz döndürdü");
						}
					}
				}
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				if (GameObject.Find ("Nokta" + (noktaIndexer - 1))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.y > GameObject.Find ("Nokta" + (noktaIndexer - 1)).transform.position.y) {
						if (GameObject.Find ("Nokta" + (noktaIndexer - 1)).GetComponent<Node> ().enable) {
							noktaIndexer -= 1;
						}
					}
				}
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				if (GameObject.Find ("Nokta" + (noktaIndexer - ekranIndex))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.x > GameObject.Find ("Nokta" + (noktaIndexer - ekranIndex)).transform.position.x) {
						if (GameObject.Find ("Nokta" + (noktaIndexer - ekranIndex)).GetComponent<Node> ().enable) {
							noktaIndexer -= ekranIndex;
						}
					}
				}
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				if (GameObject.Find ("Nokta" + (noktaIndexer + ekranIndex))) {
					if (GameObject.Find ("Nokta" + noktaIndexer).transform.position.x < GameObject.Find ("Nokta" + (noktaIndexer + ekranIndex)).transform.position.x) {
						if (GameObject.Find ("Nokta" + (noktaIndexer + ekranIndex)).GetComponent<Node> ().enable) {
							noktaIndexer += ekranIndex;
						}
					}
				}
			}
		}
		transform.position = GameObject.Find ("Nokta"+noktaIndexer).transform.position + new Vector3(0,0,zz);
	}*/
}
