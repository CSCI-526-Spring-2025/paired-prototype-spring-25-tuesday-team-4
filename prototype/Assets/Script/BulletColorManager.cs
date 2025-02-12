using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColorManager : MonoBehaviour
{
    private GunController gunController;
    private SpriteRenderer sr;

    void Start()
    {
        gunController = FindObjectOfType<GunController>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.color = ColorManager.GetColor(gunController.getCurrentColor());
    }
}
