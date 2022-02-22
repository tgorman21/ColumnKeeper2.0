using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UIManager : MonoBehaviour
{
    private Animator anim;

    private void Start() => anim = GetComponent<Animator>();

    public void StoryMode() => anim.SetTrigger("storymode");
    public void EndlessMode() => anim.SetTrigger("endless");

    public void Act1() => anim.SetTrigger("act1");
    public void Act2() => anim.SetTrigger("act2");
    public void Act3() => anim.SetTrigger("act3");

    public void Poof() => transform.GetChild(0).GetComponent<ParticleSystem>().Play();

    public void LevelSelect(int levelNum)
    {
        anim.SetTrigger("predialog");

        //setup storybook script here with correct .txt file based on given levelNum int
    }


}
