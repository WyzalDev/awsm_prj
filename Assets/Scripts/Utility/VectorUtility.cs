using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtility
{
   
    public static Vector2 Vector3ToVector2WithoutOneAxis(Vector3 vector, Axis missingAxes) {
        Vector2 resultVector = Vector2.zero;
        switch(missingAxes) {
            case Axis.x :
            {
                resultVector.x = vector.y;
                resultVector.y = vector.z;
                break;
            }
            case Axis.y :
            {
                resultVector.x = vector.x;
                resultVector.y = vector.z;
                break;
            }
            case Axis.z :
            {
                resultVector.x = vector.x;
                resultVector.y = vector.y;
                break;
            }
        }
        return resultVector;
    }

}

public enum Axis{
    x,
    y,
    z
}
