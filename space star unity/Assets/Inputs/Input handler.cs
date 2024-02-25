using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inputhandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction touchPositionAction;
    private InputAction touchTapAction;
    private Camera _mainCamera;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions["TapPos"];
        touchTapAction = playerInput.actions["Tap"];
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        touchTapAction.performed += TouchTapped;
    }

    private void OnDisable()
    {
        touchTapAction.performed -= TouchTapped;
    }

    private void TouchTapped(InputAction.CallbackContext context)
    {
        Vector3 position = _mainCamera.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
        Vector2 camPos = touchPositionAction.ReadValue<Vector2>();
        Vector3 camPosition = new Vector3(camPos.x, camPos.y, 0);

        Debug.Log(position);
        Debug.Log(camPos);
        //if (!context.started) return;
        Ray ray = _mainCamera.ScreenPointToRay(camPosition);
        var rayhit = Physics2D.GetRayIntersection(ray);
        if (!rayhit.collider) return;
        Debug.Log(rayhit.collider.gameObject.name);
    }
}
