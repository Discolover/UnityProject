using UnityEngine;
//to do:
//1. fixed update?
//2.
public class RotationUntilAngle : MonoBehaviour {
    public float fromAngle = 0;
    public float toAngle = 90;
    public float step = 0.05f;

	void Update () {
        if(fromAngle <= toAngle) { 
        transform.rotation = Quaternion.Euler(0f, 0f, fromAngle);
        fromAngle += step;
        }
    }
}
