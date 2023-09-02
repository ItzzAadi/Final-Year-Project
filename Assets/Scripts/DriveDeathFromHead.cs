using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveDeathFromHead : MonoBehaviour
{   /* 
    public static DriveDeathFromHead instance;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
    } */

    private void OnCollisionEnter2d(Collision2D collision){
        Debug.Log("OnCollisionEnter2d() has been called");
        if(collision.gameObject.CompareTag("Ground")){
            GameManager.instance.GameOver();
            Debug.Log("Head has touched the Ground");
        }
    }

}
