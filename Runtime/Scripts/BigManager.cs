using System;
using System.Collections;
using UnityEngine;

public class BigManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    private AlphabetDragAndDropEntryPoint alphabetDragAndDropEntryPoint;
    private void OnEnable()
    {
        _gameManager.OnGameOver += SetFinishForPackage;
    }

    private void OnDisable()
    {
        _gameManager.OnGameOver -= SetFinishForPackage;
    }
    
    public void SetEntryPoint(AlphabetDragAndDropEntryPoint entryPoint)
    {
        alphabetDragAndDropEntryPoint = entryPoint;
    }

    private void SetFinishForPackage()
    {
        StartCoroutine(FinishAfterFireWorks());
        

    }

    private IEnumerator FinishAfterFireWorks()
    {
        yield return new WaitForSecondsRealtime(5f);
        alphabetDragAndDropEntryPoint.InvokeGameFinished();
        Debug.Log("Finish called");
    }
}