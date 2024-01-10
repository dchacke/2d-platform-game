using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cherryCountDisplay;

    private int cherryCount = 0;
    public int CherryCount
    {
        get
        {
            return cherryCount;
        }
        private set
        {
            cherryCount = value;
            cherryCountDisplay.text = $"{value}";
        }
    }

    public void IncCherryCount()
    {
        CherryCount++;
    }
}
