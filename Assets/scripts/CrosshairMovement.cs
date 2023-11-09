using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    /*
     * WARNING: The canvas parent of this crosshair needs to have
     * RenderMode = "Screen Space - Overlay" for this to work properly
     */

    public float initXVelocity; // Define in component view
    public Camera cam;
    public GameObject board;

    private float _currentVX;
    // Board upper (x,y) bounds in pixels
    private Vector2 _upperBound;
    // Board lower (x,y) bounds in pixels
    private Vector2 _lowerBound;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentVX = initXVelocity;

        // Find upper and lower bounds of crosshair movement ahead of time
        // Using Renderer.bounds to avoid hardcoding
        // r.bounds.extents returns size of board mesh/2
        Renderer r = board.GetComponent<Renderer>();
        // First get bounds as world points
        float boardHalfW = r.bounds.extents.x * board.transform.lossyScale.x,
            boardHalfH = r.bounds.extents.y * board.transform.lossyScale.y;
        // Top right corner of board
        _upperBound = new Vector2(
            board.transform.position.x + boardHalfW,
            board.transform.position.y + boardHalfH);
        // Bottom left corner of board
        _lowerBound = new Vector2(
            board.transform.position.x - boardHalfW,
            board.transform.position.y - boardHalfH);

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
        Vector2 screenPos = new Vector2(transform.position.x,
            Mathf.Clamp(Input.mousePosition.y, _lowerBound.y, _upperBound.y));

        // Check x bounds
        if (screenPos.x < _lowerBound.x || screenPos.x > _upperBound.x)
        {
            _currentVX *= -1; // Turn around
        }

        transform.position = new Vector3(
            screenPos.x + _currentVX * Time.deltaTime,
            screenPos.y, transform.position.z);
    }

    void FreezeOnShoot() // Will be called by shoot component
    {
        _currentVX = 0;
    }

    void ResetValues() // Will be called by shoot component
    {
        _currentVX = initXVelocity;
        // Crosshair always starts in center of screen
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
