using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{

    public GameObject LHand;
    public GameObject RHand;
    public Rigidbody Projectile;
    [SerializeField] int ProjectileSpeed = 20;
    bool fire = false;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && fire == false)
        {
            Shoot(LHand);
        }

        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && fire == false)
        {
            Shoot(RHand);
        }

        if (fire == true && !(OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)))
        {
            fire = false;
        }
    }

    void Shoot(GameObject Hand)
    {
        fire = true;
        Rigidbody clone = Instantiate(Projectile, Hand.transform.position, Hand.transform.rotation) as Rigidbody;
        clone.velocity = Hand.transform.TransformDirection(new Vector3(0, 0, ProjectileSpeed));
        Destroy(clone.gameObject, 3);
    }
}
