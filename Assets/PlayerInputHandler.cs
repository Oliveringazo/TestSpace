using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    GameFlowManager m_GameFlowManager;
    PlayerCharacterController m_PlayerCharacterController;
    bool m_FireInputWasHeld;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerCharacterController = GetComponent<PlayerCharacterController>();
        m_GameFlowManager = FindObjectOfType<GameFlowManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
        m_FireInputWasHeld = GetFireInputHeld();
    }

    public bool CanProcessInput()
    {
        return !m_GameFlowManager.gameIsEnding;
    }

    public Vector2 GetMoveInput()
    {
        if (CanProcessInput())
        {
            float x = 0;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                x = -1;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                x = 1;
            }
            Vector2 movement = new Vector2( x, 0 );
            return movement;
        }

        return Vector2.zero;
    }

    public bool GetFireInputHeld()
    {
        if (CanProcessInput())
        {
            return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        }

        return false;

    }

    public bool GetFireInputDown()
    {
        return GetFireInputHeld() && !m_FireInputWasHeld;
    }

    public bool GetFireInputReleased()
    {
        return !GetFireInputHeld() && m_FireInputWasHeld;
    }

}
