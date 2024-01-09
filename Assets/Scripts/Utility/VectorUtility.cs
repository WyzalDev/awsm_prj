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

    public static Vector2 Vector3ButOneAxisIsZero(Vector3 vector, Axis missingAxes) {
        Vector3 resultVector = Vector2.zero;
        switch(missingAxes) {
            case Axis.x :
            {
                resultVector.x = 0;
                resultVector.y = vector.y;
                resultVector.z = vector.z;
                break;
            }
            case Axis.y :
            {
                resultVector.x = vector.x;
                resultVector.y = 0;
                resultVector.z = vector.z;
                break;
            }
            case Axis.z :
            {
                resultVector.x = vector.x;
                resultVector.y = vector.y;
                resultVector.z = 0;
                break;
            }
        }
        return resultVector;
    }
    public static Vector3 Vector3Clamp(Vector3 vector, Vector3 min, Vector3 max){
        Vector3 result = new Vector3();
        result.x = Mathf.Clamp(vector.x, min.x, max.x);
        result.y = Mathf.Clamp(vector.y, min.y, max.y);
        result.z = Mathf.Clamp(vector.z, min.z, max.z);
        return result;
    }
}

public enum Axis{
    x,
    y,
    z
}
