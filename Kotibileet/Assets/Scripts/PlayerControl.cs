﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    public int playerNumber = 1;
    public string horizontalCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";
    public string fireButton = "Fire1_P1";

    public int boozeCapacity = 0;
    public Slider boozeSlider;

    public bool move = true;

    public GameObject poof;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNumber == 1)
        {
            if (Input.GetButton(fireButton))
            {
                VacuumScript.vacuuming = true;
            }
            else
            {
                VacuumScript.vacuuming = false;
            }
        }
        else
        {
            if(Input.GetButtonDown(fireButton))
            {
                audioSource.Play();
            }
            if (Input.GetButton(fireButton))
            {
                
                GetComponent<VomitScript>().puke(playerNumber);
            }
        }
        /*
        if(Input.GetKey("space"))
        {
            VacuumScript.vacuuming = true;
        }
        else
        {
            VacuumScript.vacuuming = false;
        }
        */

        if (transform.position.x > 15 || transform.position.y > 15 || transform.position.y < -15 || transform.position.x < -15)
            transform.position = new Vector3(0, 1, -1);
    }

    private void FixedUpdate()
    {
        if (move)
        {
            // Cache the horizontal input
            float h = Input.GetAxis(horizontalCtrl);
            // Cache the vertical input
            float v = Input.GetAxis(verticalCtrl);
            //GetComponent<VomitScript>().Move(h, v);

            GetComponent<VomitScript>().turn(v, h);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (playerNumber != 1 && other.gameObject.GetComponent<PlayerControl>() && other.gameObject.GetComponent<PlayerControl>().playerNumber == 1)
        {
            //GameObject poofClone = Instantiate(poof, transform.position, Quaternion.identity);
            //transform.position = new Vector3(0, 1, -1);
            ////poofClone.transform.position = transform.position;
            //move = false;
            //Invoke("ActivateMove", 3);
            StartCoroutine(TeleportPlayerToToilet());
        }
    }

    public IEnumerator TeleportPlayerToToilet()
    {
        move = false;

        GameObject poofClone = Instantiate(poof, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(.5f);

        transform.position = new Vector3(0, 1, -1);
        GameObject poofClone2 = Instantiate(poof, transform.position, Quaternion.identity);
        Destroy(poofClone);

        yield return new WaitForSeconds(.5f);

        Destroy(poofClone2);

        Invoke("ActivateMove", 3);

    }

    public void ActivateMove()
    {
        move = true;
    }
}
