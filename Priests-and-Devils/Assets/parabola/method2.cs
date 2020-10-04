using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class method2 : MonoBehaviour
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
        Vector3 temp = new Vector3(vX * Time.deltaTime, - vY * Time.deltaTime, 0);
        transform.position += temp;
    }
}
