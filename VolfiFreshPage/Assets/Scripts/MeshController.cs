using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour {
    public Material mat;
    public GameObject dot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mat = GetComponent<MeshRenderer>().material;
	}
}
