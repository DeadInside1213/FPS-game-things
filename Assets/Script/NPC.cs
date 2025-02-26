using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class NPC : MonoBehaviour
{
    [SerializeField] public Missionmanager missionmanager;

    public GameObject NPCPanel; //panel

    public TextMeshProUGUI NPCContent; //text
    public TextMeshProUGUI NPCName; // name

    public List<string> content; //nội hội thoại
    public List<string> name; // who tak


    public List<WhosTaking> whosTakings;


    private Coroutine coroutine;

// Start is called before the first frame update


    private void Awake()
    {

    }

    void Start()
    {
        NPCPanel.SetActive(false);
        NPCContent.text = "";

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            NPCPanel.SetActive(true);
            //chạy chữ
            coroutine = StartCoroutine(ReadContent());
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NPCPanel.SetActive(false);
            StopCoroutine(coroutine);
            NPCContent.text = "";
        }
    }

    private IEnumerator ReadContent()
    {
        for (int i = 0; i < content.Count; i++)
        {
            NPCName.text = "";
            NPCContent.text = "";
            NPCName.text = name[i];
            foreach (var v in content[i])
            {
                NPCContent.text += v;
                yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForSeconds(0.5f);
        }

        //câu 1, câu 2, câu3
        missionmanager.BeginMission();
    }

    public class WhosTaking
    {
        public string SpeakerName { get; set; }
        public string Dialogue { get; set; }
    }

    public void Skip()
    {
        NPCPanel.SetActive(false);
        StopCoroutine(coroutine);
        missionmanager.BeginMission();
    }
}
