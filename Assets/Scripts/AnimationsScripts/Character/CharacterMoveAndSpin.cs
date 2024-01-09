using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveAndSpin : MonoBehaviour {
    // private Vector3 MoveV3 = new Vector3(30,0,0);

    // private float Move = 30f;

    // private float Stop = 0f;

    // private float currentMove;

    // private float direction;

     public float MoveSpeed;

     public float RotationSpeed;

    private Vector3 endPosition = new Vector3(0, 0, 0);

    void Start() {
 //     currentMove = Move;
 //       direction = -1f;
    }


    void Update() {
            transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime * MoveSpeed);
            transform.Rotate(new Vector3(0,Time.deltaTime * RotationSpeed, 0));
            
            // if(transform.position.x > endPosition.x){
            //      transform.Rotate(0, 110 * Time.deltaTime, 0, Space.Self);
            // }
    //    if (currentMove > 15) {
    //    currentMove = Mathf.Clamp(currentMove + Time.deltaTime * speed * direction, Stop, Move);
    //    transform.position = new Vector3(currentMove, 0, 0);
    //    transform.Rotate (0, 150 * Time.deltaTime, 0, Space.Self);
     //-   }
     //--   if (15 >= currentMove && currentMove > 0 ){
       // currentMove = Mathf.Clamp(currentMove + Time.deltaTime * (speed -5) * direction, Stop, Move);
       // --transform.position = Vector3.Lerp(transform.position, MoveV3, Time.deltaTime * (speed -5));
    //    transform.position = new Vector3(currentMove, 0, 0);
    //    transform.Rotate (0, 38 * Time.deltaTime, 0, Space.Self);
    //    }
      
    }
}