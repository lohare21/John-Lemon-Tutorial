 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Movement : MonoBehaviour {
 // Use this for initialization
 void Start () {
     
 }
 public float speed = 5f;
 void Update () {
     if (Input.GetKey(KeyCode.LeftArrow))
     {
         Vector3 position = this.transform.position;
         position.x--;
         this.transform.position = position * speed;
     }
     if (Input.GetKey(KeyCode.RightArrow))
     {
         Vector3 position = this.transform.position;
         position.x++;
         this.transform.position = position * speed;
     }
 }
     
 }