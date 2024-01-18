using UnityEngine;

public class CharacterMoving : MonoBehaviour
{
    private float MoveRight = 30f;

    private float MoveLeft = -32f;
    private float currentMove;

    private float direction;

    [Header("Settings")]
    [SerializeField]
    private float speed;

    void Start() {
        currentMove = MoveRight;
        direction = -1f;
    }


    void Update()
    {
        if (currentMove == MoveLeft || currentMove == MoveRight) {
            direction *= -1;
            transform.Rotate (0, 180, 0);
        }
        currentMove = Mathf.Clamp(currentMove + Time.deltaTime * speed * direction, MoveLeft, MoveRight);
        transform.position = new Vector3(currentMove, 0, 0);
    }
}
