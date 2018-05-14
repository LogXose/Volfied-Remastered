using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boarder : MonoBehaviour {
	public int textureBorderX = 21;
	public Vector3[,] dotVectors;
    public GameObject[,] dotObjects;
	public GameObject nokta;
	public Material material;
	private GameObject Meshes;
    public GameObject rightPrefab;
    public GameObject downPrefab;
	public bool eski = false;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    void Start(){
		dotVectors = new Vector3[textureBorderX+1,textureBorderX+1];
        dotObjects = new GameObject[textureBorderX + 1, textureBorderX + 1];
        Meshes = new GameObject ();
		Meshes.name = "Meshes";
		int ii = 0;
        int jj = 0;

		for (int i = -textureBorderX/2; i <= textureBorderX/2; i++) {
			for (int j = -textureBorderX/2; j <= textureBorderX/2; j++) {
				dotVectors [ii,jj] = new Vector3 (i, j);
                jj++;
			}
            ii++;
            jj = 0;
		}
        ii = 0;
        for (int i = -textureBorderX / 2; i <= textureBorderX / 2; i++)
        {
            for (int j = -textureBorderX / 2; j <= textureBorderX / 2; j++)
            {
                GameObject dot = (GameObject)Instantiate(nokta, dotVectors[ii, jj], Quaternion.identity);
                dotObjects[ii, jj] = dot;
                dot.transform.SetParent(transform);
                dot.name = "Nokta" + ii+ ","+jj;
                dot.GetComponent<Node>().xx = ii;
                dot.GetComponent<Node>().yy = jj;
                dot.GetComponent<Node>().sizeOfMap = textureBorderX;
                GameObject right = Instantiate(rightPrefab, dot.transform);
                GameObject down = Instantiate(downPrefab, dot.transform);
                right.SetActive(false);
                down.SetActive(false);
                right.name = "right";
                down.name = "down";
                dot.GetComponent<Node>().boarder = this.gameObject;
                if (ii == 0 || jj == 0 || ii == textureBorderX || jj == textureBorderX )
                {
                    dot.GetComponent<Node>().state = Node._nodeState.walkable;
                }
                jj++;
            }
            ii++;
            jj = 0;
        }
        ii = 0;
        for (int i = -textureBorderX / 2; i < (textureBorderX / 2); i++)
        {
            for (int j = -textureBorderX / 2; j < (textureBorderX / 2); j++)
            {
                CircuitMeshCreate(ii,jj, textureBorderX);
                jj++;
            }
            ii++;
            jj = 0; 
        }
        ii = 0;
    }

	void CircuitMeshCreate(int i,int j,int textureBorderX){
		GameObject circuit = new GameObject ("Circuit "+ i+","+j, typeof(MeshFilter), typeof(MeshRenderer));
		circuit.transform.position = dotVectors [i,j];
        circuit.GetComponent<MeshRenderer>().allowOcclusionWhenDynamic = false;

        // circuit.isStatic = true;
        Vector3[] vertices = {
			new Vector3 (0, 0),
			new Vector3 (1, 0),
			new Vector3 (1, 1),
			new Vector3 (0, 1)
		};
		int[] triangles = {
			0,3,1,
			2,1,3
		};
		Vector3[] normals = {
			new Vector3(0,0,1),
			new Vector3(0,0,1),
			new Vector3(0,0,1),
			new Vector3(0,0,1)
		};
		Vector2[] uvs = {
			new Vector2 (		(float)i / textureBorderX, 				(float)j/ textureBorderX),
			new Vector2 (		(float)(i + 1) / textureBorderX, 		(float)j / textureBorderX),
			new Vector2 (		(float)(i + 1) / textureBorderX, 		(float)(j+1) / textureBorderX),
			new Vector2 (		(float)i / textureBorderX, 				(float)(j+1) / textureBorderX)
		};

        Mesh mesh = new Mesh ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;
		mesh.uv = uvs;



		MeshFilter m_Filter = circuit.transform.GetComponent<MeshFilter> ();
        m_Filter.mesh = mesh;
        
		MeshRenderer m_Renderer = circuit.transform.GetComponent<MeshRenderer> ();
        // m_Renderer.sharedMaterial = material;
        m_Renderer.material = material;
		circuit.transform.SetParent (this.Meshes.transform);
	}

}
