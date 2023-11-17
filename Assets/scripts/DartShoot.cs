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

            // Wait for power bar to finish
            StartCoroutine(WaitForPowerBar());
        }
    }

    // Coroutine to wait for power bar to finish
    IEnumerator WaitForPowerBar()
    {
        float power = -1f;
        while (power < 0)
        {
            power = powerBar.GetComponent<PowerSelect>().GetPower();
            yield return null;
        }
        // Use crosshair position to cast ray
        Ray ray = cam.ScreenPointToRay(transform.position);

        // Create Dart and give direction, the dart fly component handles the rest
        // Assuming dart model 'points' in +z
        GameObject dart = GameObject.Instantiate(dartPrefab, cam.transform.position,
                Quaternion.LookRotation(ray.direction));
        dart.GetComponent<DartFly>().power = power;
    }
}
