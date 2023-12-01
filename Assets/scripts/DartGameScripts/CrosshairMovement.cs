using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    /*
     * WARNING: The canvas parent of this crosshair needs to have
     * RenderMode = "Screen Space - Overlay" for this to work properly
     */

    public GameObject controller;
    // Side to side velocity in pixels/second
    public float initXVelocity;
    public Camera cam;
    // Board to bound crosshair to
    public GameObject board;

    private float _currentVX;
    // Board upper (x,y) bounds in pixels
    private Vector2 _upperBound;
    // Board lower (x,y) bounds in pixels
    private Vector2 _lowerBound;
    private DartGameController _controllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        _controllerScript = controller.GetComponent<DartGameController>();
        _currentVX = initXVelocity;

        // Find upper and lower bounds of crosshair movement ahead of time
        // Using Renderer.bounds to avoid hardcoding
        Renderer r = board.GetComponent<Renderer>();
        // Top right corner of board
        _upperBound = board.transform.position + r.bounds.extents;
        // Bottom left corner of board
        _lowerBound = board.transform.position - r.bounds.extents;
        // But, now we need to convert that to screen coordinates
        _upperBound = cam.WorldToScreenPoint(_upperBound);
        _lowerBound = cam.WorldToScreenPoint(_lowerBound);
    }

    // Update is called once per frame
    void Update()
    {
        // If crosshair hits edge of board turn around
        // + clamp mouse position to keep it in line vertically
        // If this is on a screen space canvas, transform.position is in pixels
        if (_controllerScript.state == DartGameState.Aiming)
        {
            Vector2 screenPos = new Vector2(transform.position.x,
            Mathf.Clamp(Input.mousePosition.y, _lowerBound.y, _upperBound.y));

            // Check x bounds
            if (screenPos.x < _lowerBound.x || screenPos.x > _upperBound.x)
            {
                _currentVX *= -1; // Turn around
            }

            // Check for pause to stop y movement
            if (Time.timeScale == 0) screenPos.y = transform.position.y;

            transform.position = new Vector3(
                screenPos.x + _currentVX * Time.deltaTime,
                screenPos.y, transform.position.z);
        }
    }
}
