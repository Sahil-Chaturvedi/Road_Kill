using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitch : MonoBehaviour
{
    public BoxCollider mainCollider;
    public GameObject ThisGuysRig;
/*    public Animator ThisGuysAnimator;
*/    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RagdollModeOn();
        }
    }
    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidbodies;
    void GetRagdollBits()
    {
        ragDollColliders = ThisGuysRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = ThisGuysRig.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollModeOn()
    {
/*        ThisGuysAnimator.enabled = false;
*/
        foreach (Collider collider in ragDollColliders)
        {
            collider.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    void RagdollModeOff()
    {
        foreach(Collider collider in ragDollColliders) 
        { 
            collider.enabled = false; 
        }
        foreach(Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }

/*        ThisGuysAnimator.enabled = true;
*/        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
