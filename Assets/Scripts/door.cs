using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{

    //public Animator door;
    public GameObject openText;

    //public AudioSource doorSound;
    private bool isOpen = false;

    public bool inReach;
   
    void Start()
    {
        inReach = false;
        openText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))//(other.gameObject.tag != "Player")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            DoorOpens();
        }
        else
        {
            DoorCloses();
        }
        void Update()
        {
            RaycastHit promien;

            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Physics.Raycast(transform.position, transform.forward, out promien, 15))
                {
                    if (promien.collider.gameObject.tag == "door")
                    {
                        isOpen = !isOpen;

                        // Set the Animator parameter accordingly
                        this.GetComponent<Animator>().SetBool("open", isOpen);
                    }
                }
            }
        }

    }
    void DoorOpens()
    {
        //Debug.Log("It Opens");
        // door.SetBool("Open", true);
        // door.SetBool("Closed", false);
        //doorSound.Play();
        this.GetComponent<Animator>().SetBool("open", true);

    }
    void DoorCloses()
    {
        //Debug.Log("It Closes");
        //door.SetBool("Open", false);
        //door.SetBool("Closed", true);
        this.GetComponent<Animator>().SetBool("open", false); //close door
    }



}
