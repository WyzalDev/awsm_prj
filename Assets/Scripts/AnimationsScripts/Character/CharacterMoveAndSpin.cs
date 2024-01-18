using UnityEngine;

public class CharacterMoveAndSpin : MonoBehaviour {

   [Header("Settings")]
   [SerializeField]
   private float moveSpeed;

   [SerializeField]
   private float rotationSpeed;

   private Vector3 endPosition = new Vector3(0, 0, 0);

   void Update() {
      transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime * moveSpeed);
      transform.Rotate(new Vector3(0,Time.deltaTime * rotationSpeed, 0));
   }
}