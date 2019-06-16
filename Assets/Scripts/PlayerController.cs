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
    public float timeToGetEnergy = 1.5f;
    private bool GetEnergy = true;

    private bool platVisualize = false;
    public float radius = 2f;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if (!m_jump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentEnergy = motor.getCurrentEnergy();
            }
            m_jump = Input.GetKey(KeyCode.Space);

        }
        else
        {
            StartCoroutine(JumpCount());
        }

        if (!platVisualize)
        {
            platVisualize = Input.GetKey(KeyCode.J);
        }

        if (platVisualize)
        {
            platVisualMethor();
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

    private IEnumerator JumpCount()
    {
        GetEnergy = false;
        yield return new WaitForSeconds(timeToGetEnergy);
        GetEnergy = true;
    }

    public bool canGetEnergy()
    {
        return GetEnergy;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        motor.Move(horizontal, m_jump, currentEnergy);
        m_jump = false;
    }

    private void platVisualMethor()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "root")
            {
                GameObject temp = colliders[i].gameObject;
                if (temp.GetComponent<Collider2D>().isTrigger == true)
                {
                    temp.GetComponent<Collider2D>().isTrigger = false;
                    temp.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
    }

    public void unVisual()
    {
        platVisualize = false;
    }

}
