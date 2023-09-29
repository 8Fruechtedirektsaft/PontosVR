using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMessage : MonoBehaviour
{
    void Start()
    {
        grabbableTrident.GrabbedEvent += OnGrabbedEvent; 
    }

    public void OnGrabbedEvent()
    {
        winMessage.SetActive(true);
        grabbableTrident.GrabbedEvent -= OnGrabbedEvent;
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainScene");
    }

    [SerializeField]
    private ClawGrabbable grabbableTrident;
    [SerializeField]
    private GameObject winMessage;
}
