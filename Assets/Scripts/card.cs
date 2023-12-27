using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;
    public AudioClip flip;
    public AudioSource audioSource;
    void Start()
    {
        
    }
    void Update()
    {

    }
    public void openCard()
    {

        audioSource.PlayOneShot(flip);
        anim.SetBool("isOpen", true);
        if (gameManager.I.firstCard == null)
        {
            openCardS();
            gameManager.I.firstCard = gameObject;
        }
        else
        {
            openCardS();
            gameManager.I.secondCard = gameObject;
            gameManager.I.isMatch();
        }

        
    }
    public void openCardS()
    {
        
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);
    }
    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 1.0f);
    }

    void destroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void closeCard()
    {
        Invoke("closeCardInvoke", 1.0f);
    }

    void closeCardInvoke()
    {
        anim.SetBool("isOpen", false);
        transform.Find("back").gameObject.SetActive(true);
        transform.Find("front").gameObject.SetActive(false);
    }
}
