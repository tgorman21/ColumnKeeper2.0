using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFade : MonoBehaviour
{
    public void ExitLevel() => SceneManager.LoadScene(0);
}
