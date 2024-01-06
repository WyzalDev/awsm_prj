using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Navigator : MonoBehaviour
{

    public float turn_speed = 50f;

    public GameObject follows;

    private GameObject arrow;

    public float disappearDistance;

    void Start()
    {
        arrow = transform.GetChild(0).gameObject;
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
            Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * turn_speed);
    }

}
