using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ChangeLevel : MonoBehaviour
{
    public void ChangeToScene(string sceneName)
    {
        DOTween.KillAll();
        SceneManager.LoadScene("Level " + sceneName);
    }
}
