using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    [SerializeField]
    float m_MoveSpeedMultiplier = 1f;
    [SerializeField]
    GameObject m_Model;

    Rigidbody m_Rigidbody;
    Animator m_Animator;    
    const float k_Half = 0.5f;
    float m_ForwardAmount;
    Vector3 m_GroundNormal;
    float m_CapsuleHeight;
    Vector3 m_CapsuleCenter;
    CapsuleCollider m_Capsule;

    float m_InteractRadius = 5;


    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Capsule = GetComponent<CapsuleCollider>();
        m_CapsuleHeight = m_Capsule.height;
        m_CapsuleCenter = m_Capsule.center;

        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Find closest interactable 
        var colliders = Physics.OverlapSphere(transform.position, m_InteractRadius);

        float minDist = Mathf.Infinity;
        GameObject nearestObject = null;
        foreach (var collider in colliders)
        {
            if (collider.gameObject.name != "Blacksmith")
            {
                continue;
            }

            var closestPoint = collider.ClosestPointOnBounds(transform.position);
            var dist = Vector3.Distance(closestPoint, transform.position);
            if (dist < minDist)
            {
                nearestObject = collider.gameObject;
                minDist = dist;
            }
        }

        if (nearestObject != null)
        {
            //Debug.Log("Near: " + nearestObject.name);
        }
    }


    public void Move(Vector3 move)
    {
        if (move.magnitude == 0)
        {
            m_Animator.SetFloat("Forward", 0, 0.1f, Time.deltaTime);
            return;
        }

        // convert the world relative moveInput vector into a local-relative
        // turn amount and forward amount required to head in the desired
        // direction.
        if (move.magnitude > 1f) move.Normalize();
        transform.rotation = Quaternion.LookRotation(move);
        move = transform.InverseTransformDirection(move);
        move = Vector3.ProjectOnPlane(move, m_GroundNormal);
        var turnAmount = Mathf.Atan2(move.x, move.z);
        m_ForwardAmount = move.z;

        m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
    }

    public void OnAnimatorMove()
    {
        // we implement this function to override the default root motion.
        // this allows us to modify the positional speed before it's applied.
        if (Time.deltaTime > 0)
        {
            Vector3 v = (m_Animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;

            // we preserve the existing y part of the current velocity.
            v.y = m_Rigidbody.velocity.y;
            m_Rigidbody.velocity = v;
        }
    }
}
