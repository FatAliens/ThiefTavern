using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButtons1 : MonoBehaviour
{
    public GameObject ClergyChosen;
    public Animator ClergyAnimator;
    public GameObject AristocracyChosen;
    public Animator AristocracyAnimator;
    public GameObject CraftmenChosen;
    public Animator CraftmenAnimator;
    public GameObject CityzensChosen;
    public Animator CityzensAnimator;

    void Start()
    {
        /*AristocracyAnimator = AristocracyChosen.GetComponent<Animator>();
        CraftmenAnimator = CraftmenChosen.GetComponent<Animator>();
        CityzensAnimator = CityzensChosen.GetComponent<Animator>(); */
    }
    public void ClergyButton()
    {
        ClergyChosen.SetActive(true);
        ClergyAnimator = ClergyChosen.GetComponent<Animator>();
        ClergyAnimator.SetBool("AnimStart", true);
        Debug.Log("ololo");
        //animator.SetFloat("Forward",v);
    }

    public void AristocracyButton()
    {
        AristocracyChosen.SetActive(true);
        AristocracyAnimator = AristocracyChosen.GetComponent<Animator>();
        AristocracyAnimator.SetBool("Start", true);
        Debug.Log("lololo");
    }
}
