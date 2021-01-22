using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public int Kills = 0;
    public GameObject gainaPrefab;
    public GameObject ctpPrefab;
    public float usedZ = -1f;

    Vadim vadim;

    public TextMeshProUGUI KillsCounterTXT;

    private void Start()
    {
        vadim = GameObject.Find("Vadim").GetComponent<Vadim>();

    }

    // Start is called before the first frame update
    public void SpawnEnemy()
    {
        Kills++;
        if(Kills % 10 == 0)
        {
            Debug.LogError("SALALL");
          //  Instantiate(ctpPrefab, new Vector3(Random.Range(-7, 7), Random.Range(-5, 5), 0), Quaternion.identity);
            
                StartCoroutine(SpawnEnemyCoroutine(ctpPrefab, Random.Range(2f, 7f)));
        }
        else
            StartCoroutine(SpawnEnemyCoroutine(gainaPrefab, Random.Range(2f, 7f)));
    }
    IEnumerator SpawnEnemyCoroutine(GameObject pfb, float t)
    {
        yield return new WaitForSeconds(t);
        var newGaina = Instantiate(pfb);
        Gaina gaina = newGaina.GetComponent<Gaina>();
        gaina.vFreq = Random.Range(0.2f, 1f);
        gaina.hFreq = Random.Range(0.12f, 0.5f);
        gaina.vPhase = Random.Range(0f, 20f);
        gaina.hPhase = Random.Range(0f, 20f);
        usedZ -= 0.1f;
        newGaina.transform.position = new Vector3(newGaina.transform.position.x, newGaina.transform.position.y, usedZ);
        usedZ -= 0.1f;
        newGaina.transform.GetChild(1).position = new Vector3(newGaina.transform.position.x, newGaina.transform.position.y, usedZ);
        usedZ -= 0.1f;
        newGaina.transform.GetChild(2).position = new Vector3(newGaina.transform.position.x, newGaina.transform.position.y, usedZ);

    }

    // Update is called once per frame
    void Update()
    {
        KillsCounterTXT.text = Kills.ToString();
        vadim.kills = Kills;

    }
}
