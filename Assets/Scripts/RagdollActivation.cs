using System;
using UnityEngine;

public class RagdollActivation : MonoBehaviour
{
    private Rigidbody[] rigidbodies;
    private Collider[] colliders;

    void Awake()
    {
        // Получение всех Rigidbody и Collider
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();

        // Деактивация в начале
        DeactivateRagdoll();
    }

    public void ActivateRagdoll()
    {
        // Активация Rigidbody и Collider
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
        }

        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }
        
        GetComponent<Rigidbody>().mass = 0;
        GetComponent<Collider>().enabled = false;
        GetComponent<Animator>().enabled = false;
    }

    private void DeactivateRagdoll()
    {
        // Деактивация Rigidbody и Collider
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = true;
        }

        foreach (Collider col in colliders)
        {
            col.enabled = false;
        }

        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
    }
}