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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered into OnTriggerEvent2D");
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameManager.instance.GameOver();
        }
    }

}
