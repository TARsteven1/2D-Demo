using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    private Collider2D isWin;
    public GameObject WinPanel;
    public GameObject MainPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        isWin = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            WinPanel.SetActive(true);
            MainPanel.SetActive(false);
            collision.gameObject.SetActive(false);
           
        }
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }

}
