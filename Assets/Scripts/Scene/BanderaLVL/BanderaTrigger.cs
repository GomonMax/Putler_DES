using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BanderaTrigger : MonoBehaviour
{
    public GameObject[] triggerSpawn;
    public GameObject[] lamp;
    public BanderaMove bandera;
    public GameObject slider;
    public GameObject dialog;
    public HeroController hero;
    public HeroController shoot;
    public GameObject Will;
    public Animator willAnime;
    public GameObject arrow;

    public AudioSource audio;
    public Music music;
    public AudioClip epic_sound;
    public AudioSource audioSource;

    private bool allow;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Hero_Player") && !allow)
        {
            audio.Stop();
            shoot.trueShoot = false;
            
            dialog.SetActive(true);
            hero.blockMovement = true;

            for(int i = 0; i < triggerSpawn.Length; i++)
            {
                triggerSpawn[i].SetActive(true);
                LampTrue();
            }

            if(Input.anyKeyDown)
            {
                audio.PlayOneShot(music.track2);
                audioSource.PlayOneShot(epic_sound);
                shoot.trueShoot = true;
                arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
                slider.SetActive(true);
                bandera.Move();
                dialog.SetActive(false);
                allow = true;
                hero.blockMovement = false;

                Will.SetActive(false);
            }
        }
    }

    void LampTrue()
    {
        for(int i = 0; i < lamp.Length; i++)
        {
            lamp[i].SetActive(true);
        }
    }
}
