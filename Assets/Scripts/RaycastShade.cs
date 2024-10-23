using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShade : MonoBehaviour
{
    private void FixedUpdate()
    {
        GetComponent<MeshRenderer>().material.color = Color.gray;
    }

    void Highlighted()
    {
        GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
