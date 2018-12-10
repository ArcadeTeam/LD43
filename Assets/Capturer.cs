﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capturer : MonoBehaviour
{
    GameManager gm;
    Absorber absorber;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        absorber = FindObjectOfType<Absorber>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (absorber.Absorbing && gm.GetAmmo() < gm.MaxAmmo)
        {
            Minion m = other.GetComponent<Minion>();
            if (m && !m.explosive && m.readyToHarvest)
            {
                gm.IncreaseAmmo();
                MinionsPool.Instance.Put(m);

                gm.audioManager.PlayOneShot(gm.audioManager.absorbed, transform.position);
            }
        }
    }
}
