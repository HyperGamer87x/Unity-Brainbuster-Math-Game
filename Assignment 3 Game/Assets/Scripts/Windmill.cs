using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour {

    public float rotationSpeed;
    public Vector3 direction;

    void Update () {
        this.transform.Rotate(direction * rotationSpeed * Time.deltaTime);
    }
}
