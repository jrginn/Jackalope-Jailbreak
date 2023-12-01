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
        if (_controllerScript.state == DartGameState.Aiming
            && Input.GetButtonDown("Fire1") && Time.timeScale != 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (ammoCounter.GetComponent<AmmoCount>().DecreaseBy1())
        {

            // Change game state
            _controllerScript.state = DartGameState.SelectingPower;
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
        DartFly df = dart.GetComponent<DartFly>();
        df.power = power;
        df.dartGameController = controller;
    }
}
