using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CrosshairMovement))]
public class DartShoot : MonoBehaviour
{
    public GameObject dartPrefab;
    public Camera cam;
    public GameObject powerBar;
    public GameObject ammoCounter;
    public GameObject controller;

    private DartGameController _controllerScript;

    // Start is called before the first frame update
    void Start()
    {
        _controllerScript = controller.GetComponent<DartGameController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_controllerScript.state == GameState.Aiming
            && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (ammoCounter.GetComponent<AmmoCount>().DecreaseBy1())
        {

            // Change game state
            _controllerScript.state = GameState.SelectingPower;
            powerBar.SetActive(true);

            // Power bar will send command to shoot
        }
    }

    public void SpawnDart(float power)
    {
        // Use crosshair position to cast ray
        Ray ray = cam.ScreenPointToRay(transform.position);

        GameObject dart = GameObject.Instantiate(dartPrefab, cam.transform.position,
                Quaternion.LookRotation(ray.direction));
        dart.GetComponent<DartFly>().power = power;
    }
}
