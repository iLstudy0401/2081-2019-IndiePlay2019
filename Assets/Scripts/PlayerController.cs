using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    private PlayerMotor motor;
    private bool m_jump = false;
  //  public GameObject platIns;
  //  private Vector2 mousePosPrevious = Vector2.zero;
  //  GameObject ins;
    private float currentEnergy;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if (!m_jump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                currentEnergy = motor.getCurrentEnergy();
            m_jump = Input.GetKey(KeyCode.Space);
        }
      /*      
        if (Input.GetMouseButtonDown(0))
        {
            mousePosPrevious = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePosLast = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = mousePosPrevious - mousePosLast;
            float angle = Vector2.Angle(dir, Vector2.left);
            Vector3 c = Vector3.Cross(dir, Vector2.right);
            int front = c.z > 0 ? -1 : 1;
            ins = Instantiate(platIns, mousePosPrevious, Quaternion.identity);
            ins.transform.RotateAround(ins.transform.position, Vector3.back, front * angle);
        }
        */
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        motor.Move(horizontal, m_jump, currentEnergy);
        m_jump = false;
    }

}
