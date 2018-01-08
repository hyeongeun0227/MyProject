using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tesdt : MonoBehaviour {

    //  public GameObject p_Cube;

    float t;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
                transform.GetComponent<Renderer>().material.SetFloat("_DissolveAmount", transform.GetComponent<Renderer>().material.GetFloat("_DissolveAmount") + 0.009f);


    }
}
