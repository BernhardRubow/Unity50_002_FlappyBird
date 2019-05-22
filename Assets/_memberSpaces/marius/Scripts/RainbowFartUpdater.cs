using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowFartUpdater : MonoBehaviour
{
    public Transform birdVisualTransform;
    public Transform particleTransform;

    // Start is called before the first frame update
    void Start() {

    }
    // Update is called once per frame
    void Update() {
        particleTransform.eulerAngles = new Vector3(0.0f, -90.0f, birdVisualTransform.eulerAngles.z);
        particleTransform.position = birdVisualTransform.position;
    }
}
