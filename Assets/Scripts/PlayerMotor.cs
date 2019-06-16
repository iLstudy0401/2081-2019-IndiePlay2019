using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMotor : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D m_playerRig;
    public float max_Speed_horizontal;
    public float max_SpeedVertical = 5f;
    public float smoothTime = 3f;
    public float maxEnergy = 2f;
    public float energyFiyTime = 2f;
    public float fireTime = 1f;
    private bool overLoad = false;
    private float current;
    private bool m_jump = false;
    private bool lowStatus = false;

    public float reverorySpeed = 1.5f;

    private void Start()
    {
        m_playerRig = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        checkEnergy();
    }

    public void Move(float _horizontal, bool _jump, float _current)
    {
        m_jump = _jump;
        float horizontal = _horizontal * 3f;
        horizontal = Mathf.Clamp(horizontal, -1, 1);
        m_playerRig.velocity = new Vector2(horizontal * max_Speed_horizontal, m_playerRig.velocity.y);

        if (_current < fireTime)
        {
            lowStatus = true;
            return;
        }
        else lowStatus = false;

        if (_jump && !overLoad)
        {
            m_playerRig.gravityScale = 0f;
            Vector2 targetVelocity = new Vector2(m_playerRig.velocity.x, max_SpeedVertical);
            m_playerRig.velocity = Vector2.Lerp(m_playerRig.velocity, targetVelocity, smoothTime * Time.deltaTime);
        }
        else
        {
            m_playerRig.gravityScale = 1f;
        }
    }

    public float getCurrentEnergy()
    {
        return energyFiyTime;
    }

    private void checkEnergy()
    {
        if (energyFiyTime < 0)
            overLoad = true;
        else overLoad = false;
        if (m_jump)
        {
            if (!overLoad)
                energyFiyTime -= Time.deltaTime;
        }
        else
        {
            if (energyFiyTime < maxEnergy && playerController.canGetEnergy())
                energyFiyTime += Time.deltaTime * (reverorySpeed);
        }
        if (lowStatus)
        {
            if (energyFiyTime < maxEnergy && playerController.canGetEnergy())
                energyFiyTime += Time.deltaTime * (reverorySpeed + 1f);
        }
    }
}
