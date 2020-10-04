using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class method4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
