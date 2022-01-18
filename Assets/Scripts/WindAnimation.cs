using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAnimation : MonoBehaviour
{
    [SerializeField] GameObject[] frames;
    [SerializeField] float timePerFrame = 0.1f;
    float currentTime = 0;
    int ptr = 0;

    void MovePtr(){
        ptr = (ptr + 1) % frames.Length;
    }
    void IncrementTimer(){
        currentTime += Hero.IsDead? 0 : Time.deltaTime;
    }
    bool IsTimeForNewFrame(){
        return currentTime >= timePerFrame;
    }
    void ClearTimer(){
        currentTime = 0;
    }
    void Update()
    {
        IncrementTimer();
        if (IsTimeForNewFrame()){
            ClearTimer();
            frames[ptr].SetActive(false);
            MovePtr();
            frames[ptr].SetActive(true);
        }
    }
}
