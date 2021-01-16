using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public string key;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.config[GameManager.PHASE_STATE] == key) {
            SetChildrenActive();
        } else {
            SetChildrenInactive();
        }
    }

    void SetChildrenInactive() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

    void SetChildrenActive() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }
    }
}
