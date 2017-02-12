﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIControl : MonoBehaviour{
	public Text title;
	public Text subTitle;
	public Text hint;
	public Text body;
	public Button play;
	public Button move;
	public Button yes;
	public Button no;

	public static bool moveClicked;
	public static bool playClicked;
	public enum UserState { title, instructions, introduction, station1, station2, station3, station4, station5 }

	[HideInInspector]
	public static UserState currentUserState;

	private float hintTimer = 10f;
	// Use this for initialization
	void Start () {
		currentUserState = UserState.title;
		StartCoroutine(DisplayHint());
	}
	
	// Update is called once per frame
	void Update () {
	}


	public void Play()
	{
		playClicked = true;
		switch (currentUserState)
		{
			case UserState.title:
				currentUserState = UserState.instructions;
				title.text = "INSTRUCTIONS";
				subTitle.text = "Buttons and their uses";
				body.gameObject.SetActive(true);
				hint.text = "Look at the button and click";
				hint.gameObject.SetActive(false);
				play.gameObject.transform.localPosition -= new Vector3(0,90,0);
				StopCoroutine(DisplayHint());
				StartCoroutine(DisplayHint());
				break;
			case UserState.instructions:
				currentUserState = UserState.introduction;
				title.text = "INTRODUCTION";
				subTitle.text = "Be amazed.";
				body.transform.GetChild(0).gameObject.SetActive(false);
				body.lineSpacing = 1;
				body.text = "Hello! This is a simple VR experience to showcase the application of virtual reality to amusement parks." +
					" Companies like VRCoaster have made it their goal to cleverly integrate virtual reality in rides like rollercoasters and haunted house. Click the GO button and let's begin!";
				hint.text = "Click the sound button to activate voice over";
				hint.gameObject.SetActive(false);
				play.gameObject.SetActive(false);
				move.gameObject.SetActive(true);
				StopCoroutine(DisplayHint());
				StartCoroutine(DisplayHint());
				break;
			case UserState.introduction:
				currentUserState = UserState.station1;
				title.text = "IMPACT OF VR";
				subTitle.text = "It's everywhere.";
				body.text = "Virtual reality has impacted many industries greatly. The most popular sects include gaming, education, tourism and even medicine." +
					"Though this is amazing, the scope of VR reach is still beyond.";
				hint.text = "You can hide images with the image button";
				hint.gameObject.SetActive(false);
				StopCoroutine(DisplayHint());
				StartCoroutine(DisplayHint());
				break;
			case UserState.station1:
				currentUserState = UserState.station2;
				title.text = "VR AMUSEMENT PARKS";
				subTitle.text = "VR Coaster";
				body.text = "VR Coaster pride themselves in the evolution of amusement park rides using virtual reality. They boast of equipping over 20 parks worldwide with virtual reality rides" +
					"and are the market leaders in terms of VR experiences on rollercoasters and rides.";
				hint.text = "Click the move button to go to next station";
				hint.gameObject.SetActive(false);
				StopCoroutine(DisplayHint());
				StartCoroutine(DisplayHint());
				break;
			case UserState.station2:
				currentUserState = UserState.station3;
				title.text = "VR RIDES";
				subTitle.text = "Examples";
				body.text = "Some of the amusement parks that offer virtual reality awesomeness include: \n Six Flags \n Cedar Fair \n Europa-Park \n Lotte World";
				hint.text = "Click on images to view them.";
				hint.gameObject.SetActive(false);
				StopCoroutine(DisplayHint());
				StartCoroutine(DisplayHint());
				break;
			case UserState.station3:
				currentUserState = UserState.station4;
				title.text = "Gallery";
				subTitle.text = "Awesome pictures.";
				hint.text = "Click on images to view them.";
				body.text = "This is the gallery. Here you can view awesome pictures of people having a lot of fun from virtual reality rides";
				hint.gameObject.SetActive(false);
				StopCoroutine(DisplayHint());
				StartCoroutine(DisplayHint());
				break;
			case UserState.station4:
				currentUserState = UserState.station5;
				title.text = "Conclusion";
				subTitle.text = "We're Done!";
				move.gameObject.SetActive(false);
				yes.gameObject.SetActive(true);
				no.gameObject.SetActive(true);
				hint.text = "Click retry to go through the experience again.";
				body.text = "I hope with this short presentation, excitement and knowledge has been passed across on the application of Virtual Reality in amusement parks. Thank you! " +
					"\n Do you want to restart the experience?";
				hint.gameObject.SetActive(false);
				StopCoroutine(DisplayHint());
				StartCoroutine(DisplayHint());
				break;
		}
	}

	public void Move()
	{
		moveClicked = true;
	}

	public void Yes()
	{
		SceneManager.LoadScene("main scene");
	}

	public void No()
	{
		Application.Quit();
	}


	IEnumerator DisplayHint()
	{
		while (!hint.gameObject.activeSelf)
		{
			yield return new WaitForSeconds(hintTimer);
			hint.gameObject.SetActive(true);
		}
	}
}
