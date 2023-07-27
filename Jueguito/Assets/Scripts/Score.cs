using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float timeScore = 0;
    public float totalScore = 0;
    
    void Start()
    {
        timeScore = 0;
        totalScore = 0;
    }

    void FixedUpdate()
    {
        timeScore += 1f * Time.fixedDeltaTime;
    }
}
