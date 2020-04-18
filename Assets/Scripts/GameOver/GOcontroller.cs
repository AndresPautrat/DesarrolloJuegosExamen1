using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GOcontroller : MonoBehaviour
{
    [SerializeField]
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() => retur());
    }
    void retur()
    {
        SceneManager.LoadScene("Menu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
