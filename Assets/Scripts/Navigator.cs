using Unity.VisualScripting;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    [Header("Navigator settings")]
    [SerializeField]
    public GameObject follows;

    [Header("Navigation Arrow settings")]

    [SerializeField]
    public float disappearDistance = 5f;

    [SerializeField]
    public float turnSpeed = 50f;

    [SerializeField]
    public float rotationArrowSpeed = 40f;

    private GameObject arrow;

    void Start()
    {
        arrow = transform.GetChild(0).GetChild(0).gameObject;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, follows.transform.position, 1);
        GameObject toLook = InteractObjectsContainer.GetCurrentInteractObject();
        if (!toLook.IsDestroyed()) {
            Vector3 to = toLook.transform.position;
            rotateTowards(to);
            float distance = (transform.position - to).magnitude;
            ChangeArrowVisibilityOnDistance(distance);
        }
    }

    private void ChangeArrowVisibilityOnDistance(float distance)
    {
        if (distance < disappearDistance) {
            if (arrow.activeSelf) {
                arrow.SetActive(false);
            }
        } else {
            if (!arrow.activeSelf) {
                arrow.SetActive(true);
            }
        }
    }

    protected void rotateTowards(Vector3 to)
    {
        Quaternion _lookRotation =
            Quaternion.LookRotation((to - transform.position).normalized);
        _lookRotation.x = 0;
        _lookRotation.z = 0;
        //over time
        transform.rotation =
            Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * turnSpeed);
        float arrowRotation = Time.deltaTime * rotationArrowSpeed;
        arrow.transform.Rotate(0, arrowRotation, 0);
    }

}
