using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light light;
    public string lightName = "Living Room";
    
    private void Awake()
    {
        print("Hello Awake!");
    }
    private void OnMouseDown()
    {
        print("MouseDown");
        light.enabled = !light.enabled;


    }


    // Start is called before the first frame update
    void Start()
    {
        print("Hello " + lightName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
