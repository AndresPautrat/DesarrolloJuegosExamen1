using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> originalCandies=new List<GameObject>();
    List<GameObject> candies = new List<GameObject>();

    float lastTime=-3;

    float LimitXmin, LimitXmax;
    [SerializeField]
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < originalCandies.Count; i++)
        {
            for (int j=0;j < 5; j++)
            {
                GameObject GO = Instantiate(originalCandies[i], new Vector3(0f, 0f, 0f), Quaternion.identity);
                GO.SetActive(false);

                candies.Add(GO);
            }
        }

        Vector3 Limits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        LimitXmax = Limits.x;
        LimitXmin = -Limits.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastTime >= 4)
        {
            lastTime = Time.time;
            SpawnCandies();
        }
        if (player.getLife()==0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void SpawnCandies()
    {
        //while (true)
       // {
            int rnd = Random.Range(0, candies.Count);
            if (!candies[rnd].activeInHierarchy)
            {
                candies[rnd].SetActive(true);
                float xPosition = Random.Range(LimitXmin, LimitXmax);
                candies[rnd].transform.localPosition = new Vector3(xPosition, 5, 1);

            }
      //  }
    }
}
