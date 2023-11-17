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

    private CrosshairMovement _cm;

    // Start is called before the first frame update
    void Start()
    {
        _cm = GetComponent<CrosshairMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        ammoCounter.GetComponent<AmmoCount>().DecreaseBy1();
        // "this" is the Crosshair gameObject
        _cm.FreezeOnShoot();
        // Use crosshair position to cast ray
        Ray ray = cam.ScreenPointToRay(transform.position);

        powerBar.SetActive(true);
        /*
         * TODO: Wait for power bar here
         */
        float power = powerBar.GetComponent<PowerSelect>().GetPower();
        powerBar.SetActive(false);

        // Create Dart and give direction, the dart fly component handles the rest
        // Assuming dart model 'points' in +z
        GameObject dart = GameObject.Instantiate(dartPrefab, cam.transform.position,
            Quaternion.LookRotation(ray.direction));
        dart.GetComponent<DartFly>().power = power;
        // Maybe wait for dart to hit here?

        // Reset crosshair pos
        _cm.ResetValues();
    }
}
