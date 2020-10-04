using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class method1 : MonoBehaviour
{   
    private float vX = 5;
    private float vY = 0;
    private float g = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vY += g * Time.deltaTime;
        transform.position += Vector3.right * vX * Time.deltaTime;
        transform.position += Vector3.down * vY * Time.deltaTime;
    }
}
