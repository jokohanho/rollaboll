using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform Target;
    public float movementSpeed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 direction = (Target.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
    }
}