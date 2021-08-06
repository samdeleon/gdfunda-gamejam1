using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinningScript : MonoBehaviour
{
    [SerializeField] private Material winningMaterial;
    [SerializeField] private GameObject winningUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WinningRoutine()
    {
        GetComponent<MeshRenderer>().material = winningMaterial;
        //enable winningUI GameObject(canvas)
        winningUI.SetActive(true);
        //Set the time scale to slowmo mode;
        Time.timeScale = 0.25f;
        //wait for 1 second, but every second in reallife is now 0.25 in our game so this wait will be around 4 seconds.
        yield return new WaitForSeconds(1f);

        Time.timeScale = 1f;

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WinningRoutine());
        }
    }
}
