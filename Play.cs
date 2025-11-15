using System;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public GameObject CameraMain;
    public GameObject CameraLevelSel;
    public GameObject Camera;
    public GameObject Win;
    public GameObject Player;
    public GameObject ResOne;
    public GameObject ResTwo;
    public GameObject ResThree;
    public GameObject BackOne;
    public GameObject BackTwo;
    public GameObject BackThree;
    public AudioSource musico;
    public AudioClip menu;
    public AudioClip lvl1;
    public AudioClip lvl2;
    public AudioClip lvl3;
    private void Start()
    {
        musico.loop = true;
        musico.volume = 0.85f;
    }
    public void CamMainy()
    {
        CameraMain.SetActive(true);
        CameraLevelSel.SetActive(false);
        Camera.SetActive(false);
        Win.SetActive(false);
        BackOne.SetActive(false);
        BackTwo.SetActive(false);
        BackThree.SetActive(false);
        musico.clip = menu;
        musico.Play();
    }
    public void CamLevelSely()
    {
        CameraMain.SetActive(false);
        CameraLevelSel.SetActive(true);
        Camera.SetActive(false);
        Win.SetActive(false);
        BackOne.SetActive(false);
        BackTwo.SetActive(false);
        BackThree.SetActive(false);
    }
    public void CamLevelOney()
    {
        CameraMain.SetActive(false);
        CameraLevelSel.SetActive(false);
        Camera.SetActive(true);
        Win.SetActive(false);
        Player.transform.position = ResOne.transform.position;
        BackOne.SetActive(true);
        BackTwo.SetActive(false);
        BackThree.SetActive(false);
        musico.clip = lvl1;
        musico.Play();
    }
    public void CamLevelTwoy()
    {
        CameraMain.SetActive(false);
        CameraLevelSel.SetActive(false);
        Camera.SetActive(true);
        Win.SetActive(false);
        Player.transform.position = ResTwo.transform.position;
        BackOne.SetActive(false);
        BackTwo.SetActive(true);
        BackThree.SetActive(false);
        musico.clip = lvl2;
        musico.Play();
    }
    public void CamLevelThreey()
    {
        CameraMain.SetActive(false);
        CameraLevelSel.SetActive(false);
        Camera.SetActive(true);
        Win.SetActive(false);
        Player.transform.position = ResThree.transform.position;
        BackOne.SetActive(false);
        BackTwo.SetActive(false);
        BackThree.SetActive(true);
        musico.clip = lvl3;
        musico.Play();
    }
    public void Winner()
    {
        CameraMain.SetActive(false);
        CameraLevelSel.SetActive(false);
        Camera.SetActive(false);
        Win.SetActive(true);
        BackOne.SetActive(false);
        BackTwo.SetActive(false);
        BackThree.SetActive(false);
        musico.clip = menu;
        musico.Play();
    }


    public void Quits()
    {
        Application.Quit();
    }
}
