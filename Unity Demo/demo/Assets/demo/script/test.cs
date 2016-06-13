using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    Color orgColor;
    bool tr1 = false;
    bool tr2 = false;

	// Use this for initialization
	void Start () {
      
       orgColor =  GetComponent<Renderer>().material.color;
       

    }
	
	// Update is called once per frame
	void Update () {

        if (tr2 == true) {

            transform.Rotate(Vector3.up * Time.deltaTime * 200);
        }
	    
	}

    void OnMouseOver() {

        GetComponent<Renderer>().material.color = Color.green;
        tr1 = true;

    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = orgColor;
        tr2 = false;
    }

    void OnMouseDown()
    {
        if (tr1==true)
        {
            tr2 = true;
        }
    }
}
