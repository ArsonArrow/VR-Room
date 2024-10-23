using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private float minSeconds;
    [SerializeField] private float maxSeconds;
    private bool targetable = false;
    private Quaternion upRot = new Quaternion(-45, 0, 0, 0);
    private Quaternion downRot = new Quaternion(0, 0, 0, 0);
    [SerializeField] private Transform targetTransform;
    [SerializeField] private GameObject targetGameObject;
    private float seconds;
    public Scorer scorerScript;

    // up targetable = true;
    // down targetable = false;

    private void Start()
    {
        targetTransform.rotation = downRot;
        targetable = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!targetable) {  return; }

        if (collision.gameObject.tag == "ball")
        {
            GotHit();
        }
    }

    private void GotHit()
    {
        targetGameObject.GetComponent<AudioSource>().Play();
        scorerScript.AddToScore();
        SetToUpState();
        seconds = Random.Range(minSeconds, maxSeconds);
        StartCoToGoDown(seconds);
    }

    public void StartCoToGoDown(float sec)
    {
        StartCoroutine(GoDown(sec));
    }

    IEnumerator GoDown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SetToDownState();
    }

    public void SetToDownState()
    {
        targetable = true;
        targetTransform.rotation = downRot;
    }

    public void SetToUpState()
    {
        targetable = false;
        targetTransform.rotation = upRot;
    }


}
