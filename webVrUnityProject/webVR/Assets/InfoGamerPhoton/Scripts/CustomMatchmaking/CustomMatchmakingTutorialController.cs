using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomMatchmakingTutorialController : MonoBehaviour
{
	int active = 0;
	int index = 0;
	private GameObject[] tutorials;
	[SerializeField]
	private GameObject tutorial01;
	[SerializeField]
	private GameObject tutorial02;
	[SerializeField]
	private GameObject tutorial03;
	[SerializeField]
	private GameObject tutorial04;
	[SerializeField]
	private GameObject tutorial05;
	[SerializeField]
	private GameObject tutorial06;
	[SerializeField]
	private GameObject tutorial07;
	[SerializeField]
	private GameObject mainPanel; //panel for displaying the main menu
	[SerializeField]
	private GameObject tutorialPanel; //panel for displaying tutorial
	[SerializeField]
	private Text pageCount; //text that holds the page count
	[SerializeField]
	private Button prevButton; //button for going to the previous tutorial
	[SerializeField]
	private Button nextButton; //button for going to the next tutorial

	public void Start()
	{
		tutorials = new GameObject[7] { tutorial01, tutorial02, tutorial03, tutorial04, tutorial05, tutorial06, tutorial07 };
	}

	public void OpenTutorialOnClick()
	{
		index = 0;
		prevButton.interactable = false;
		if (tutorials.Length > 1) nextButton.interactable = true;
		else nextButton.interactable = false;
		LoadTutorial(0);
		mainPanel.SetActive(false);
		tutorialPanel.SetActive(true);
	}

	public void CloseTutorialOnClick()
	{
		tutorialPanel.SetActive(false);
		mainPanel.SetActive(true);
	}

	public void PreviousTutorialOnClick()
	{
		if (index - 1 <= 0)
		{
			index = 0;
			prevButton.interactable = false;
		}
		else if (index + 1 == tutorials.Length)
		{
			--index;
			nextButton.interactable = true;
		}
		else
		{
			--index;
		}
		LoadTutorial(index);
	}

	public void NextTutorialOnClick()
	{
		if (index == 0)
		{
			++index;
			prevButton.interactable = true;
		}
		else if (index + 2 >= tutorials.Length)
		{
			index = tutorials.Length - 1;
			nextButton.interactable = false;
		}
		else
		{
			++index;
		}
		LoadTutorial(index);
	}

	private void LoadTutorial(int i)
	{
		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
		tutorials[active].SetActive(false);
		tutorials[index].SetActive(true);
		active = index;
		pageCount.text = string.Format("{0}/{1}", index + 1, tutorials.Length);
	}
}
