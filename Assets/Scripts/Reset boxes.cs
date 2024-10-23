using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Resetboxes : MonoBehaviour
{
    Vector3 initialPosition;
    Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.position;
        initialRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.Four))
        {
            Debug.Log("Reset boxes was called");
            this.transform.position = initialPosition;
            this.transform.rotation = initialRotation;
        }
    }
}
