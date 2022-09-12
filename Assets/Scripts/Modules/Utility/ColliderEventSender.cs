using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class ColliderEventSender : MonoBehaviour
{
    [FoldoutGroup("Ȱ��ȭ �̺�Ʈ")]
    public UnityEvent<GameObject> enableEvent;
    [FoldoutGroup("Ȱ��ȭ �̺�Ʈ")]
    public UnityEvent<GameObject> disableEvent;

    [FoldoutGroup("Collision �̺�Ʈ")]
    public UnityEvent<Collision> collisionEnterEvent;
    [FoldoutGroup("Collision �̺�Ʈ")]
    public UnityEvent<Collision> collisionStayEvent;
    [FoldoutGroup("Collision �̺�Ʈ")]
    public UnityEvent<Collision> collisionExitEvent;

    [FoldoutGroup("Trigger �̺�Ʈ")]
    public UnityEvent<Collider> triggerEnterEvent;
    [FoldoutGroup("Trigger �̺�Ʈ")]
    public UnityEvent<Collider> triggerStayEvent;
    [FoldoutGroup("Trigger �̺�Ʈ")]
    public UnityEvent<Collider> triggerExitEvent;

    private void OnEnable()
    {
        enableEvent?.Invoke(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionEnterEvent?.Invoke(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        collisionStayEvent?.Invoke(collision);
    }

    private void OnCollisionExit(Collision collision)
    {
        collisionExitEvent?.Invoke(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        triggerStayEvent?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExitEvent?.Invoke(other);
    }
    private void OnDisable()
    {
        disableEvent?.Invoke(gameObject);
    }
}
