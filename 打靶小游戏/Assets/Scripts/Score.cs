using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int goal;

    // Start is called before the first frame update
    void Start()
    {
        goal = int.Parse(this.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        ScoreRecorder.score += goal;
    }
}
