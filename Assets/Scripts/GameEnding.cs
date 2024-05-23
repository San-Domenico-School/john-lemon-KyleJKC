/*
 * GameEnding.cs
 * 
 * Used to toggle the alpha property of the
 * ExitImageBackground when the player passes
 * thru the GameEndingTrigger.
 * 
 * A component of the GamEndingTrigger
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEnding : MonoBehaviour
{ 
    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private CanvasGroup caughtBackgroundImageCanvasGroup;

    private float fadeDuration;
    private float displayImageDuration;
    private float timer;
    private bool isPlayerAtExit;
    private bool isPlayerCaught;

    // Start is called before the first frame update
    void Start()
    {
        fadeDuration = 1.0f;
        displayImageDuration = 1.0f;
    }

    // Checks if player has triggered caught or exit, then restarts or ends game.
    void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    private void EndLevel(CanvasGroup image, bool restartGame)
    {
        timer += Time.deltaTime;

        image.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            if(restartGame)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }
}
