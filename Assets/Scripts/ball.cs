using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody rigid;
    MeshRenderer mesh;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        // rigid.velocity = Vector3.right;
        // rigid.velocity = new Vector3(2, 4, 3);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.B))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rigid.AddForce(Vector3.up, ForceMode.Impulse);
                Debug.Log(rigid.velocity);
            }
            Vector3 vec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            rigid.AddForce(vec, ForceMode.Impulse);
            // Vector 값을 축으로 삼고 회전하는 힘을 가함
            // Vector3.up이나 Vector3.down을 사용하면 제자리에서 회전함
            // rigid.AddTorque(Vector3.back, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            mat.color = Color.red;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            mat.color = Color.black;
        }
    }

}
