using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // For TextMeshPro


public class BulletManager : MonoBehaviour
{
    public int maxBullets = 5;
    private int currentBullets;
    public TMP_Text bulletText;


    void Start()
    {
        currentBullets = maxBullets;
        UpdateBulletUI();
    }

    public void UpdateBulletUI()
    {
        bulletText.text = "Total Bullets: " + currentBullets;
    }

    public void FireBullet()
    {
        if (currentBullets > 0)
        {
            // currentBullets--;
            UpdateBulletUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reduceBulletCount()
    {
        currentBullets--;
    }

    public int GetBulletCount()
    {
        return currentBullets;
    }
}
