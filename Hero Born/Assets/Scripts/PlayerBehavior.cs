 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f; //1 ���������� ����� CapsuleCollider ������ � ����� �������� ���� Ground
    public LayerMask groundLayer; //2 ������� ���������� � ���������� ��� ����������� ����������

    public GameObject bullet;
    public float bulletSpeed = 100f;

    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    private CapsuleCollider _col; //3 ���������� ��� �������� CapsuleCollider ������ 

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>(); //4 � ������� ������ GetComponent() ������� � �������� ������ � CapsuleCollider ������
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        /*this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);*/
    }
    void FixedUpdate()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) // 5 �
            {
                _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            }
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation  * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (Input.GetMouseButtonDown(0))
            {
            GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
            }
    }

    private bool IsGrounded() //6 ��������� ����� IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z); //7 ���������� ������ ������ ����� ���������� 
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore); //8
        return grounded;//9

    }
}
