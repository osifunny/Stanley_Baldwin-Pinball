using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float score;

    private void Start(){
        ResetScore();
    }

    public void ResetScore(){
        score = 0;
    }

    public void AddScore(float addition){
        score += addition;
    }
}
