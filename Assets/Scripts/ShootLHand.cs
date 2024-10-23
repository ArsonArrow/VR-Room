using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootLHand : MonoBehaviour
{

    public Rigidbody Projectile;
    public int ProjectileSpeed = 20;
    private bool fire = false;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !fire)
        {
            fire = true;
            Rigidbody clone = Instantiate(Projectile, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(new Vector3(0, 0, ProjectileSpeed));
            Destroy(clone.gameObject, 3);
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) && fire)
        {
            fire = false;
        }
    }
}
