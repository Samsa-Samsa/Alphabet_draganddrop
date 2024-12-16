using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    private GameObject _bigLetter;
    private GameObject _smallLetter;

    [Header("Boards")]
    [SerializeField] GameObject _nextLetterBoard;
    [SerializeField] GameObject _nextLetterContainer;
    [SerializeField] GameObject _actualLetterBoard;
    [SerializeField] GameObject _actualLetterContainer;

    [SerializeField] GameObject _pageRipped;
    [SerializeField] Animator _animator;

    [Header("Effects")]
    [SerializeField] GameObject _conffetti;
    [SerializeField] GameObject _fireWork;
    [SerializeField] GameObject _stars;
    public  Action OnGameOver; 

    private void Start()
    {
        _animator.enabled = false;
        _bigLetter = _actualLetterBoard.transform.GetChild(0).gameObject;
        _smallLetter = _actualLetterBoard.transform.GetChild(1).gameObject;
    }

    private void FixedUpdate()
    {
        Check();
    }

    private void Check()
    {
        if(_smallLetter.GetComponent<DragAndDrop1>().IsSnapped&& _bigLetter.GetComponent<DragAndDrop1>().IsSnapped)
        {
            _smallLetter.transform.SetParent(_actualLetterContainer.transform);
            _bigLetter.transform.SetParent(_actualLetterContainer.transform);
            _actualLetterContainer.transform.SetParent(_pageRipped.transform);

            StartCoroutine(Transition());
        }
    }

    private IEnumerator Transition()
    {
        _pageRipped.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _animator.enabled = true;
        if (_nextLetterContainer != null)
        {
            _nextLetterContainer.SetActive(true);
        }
    }

    public void NextLetterBoard()
    {
        _actualLetterContainer.SetActive(false);
        if (_nextLetterBoard != null)
        {
            _actualLetterBoard.SetActive(false);
            _nextLetterBoard.SetActive(true);
        }
        else
        {
            _conffetti.SetActive(true);
            _fireWork.SetActive(true);
            OnGameOver?.Invoke();
            
        }
        Destroy(gameObject);
        Destroy(this);
    }


}