using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class LightControl : MonoBehaviour {

    //光源控制器
    public GameObject light;
    //光照强度增量
    private float addLight=0.01f;
    private GameObject text;

	// Use this for initialization
	void Start () {
        //获取光源组件
        light = GameObject.Find("Directional Light");
        text = GameObject.Find("Text");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q)) {

            light.GetComponent<Light>().intensity += addLight;
            text.GetComponent<Text>().text = "当前光源亮度为：" + light.GetComponent<Light>().intensity;
        }
        else if (Input.GetKey(KeyCode.E)) {

            light.GetComponent<Light>().intensity -= addLight;
            text.GetComponent<Text>().text = "当前光源亮度为：" + light.GetComponent<Light>().intensity;
        }
	}
}
