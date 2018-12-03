using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, freedom};
	private States myState;
	
	// Use this for initialization
	void Start () {
	myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
	print(myState);
	if(myState==States.cell)				{cell();}
	else if(myState == States.sheets_0)		{sheets_0();}
	else if(myState == States.lock_0)		{lock_0();}
	else if(myState == States.lock_1)		{lock_1();}
	else if(myState == States.mirror)		{mirror();}
	else if(myState == States.cell_mirror)	{cell_mirror();}
	else if(myState == States.mirror)		{mirror();}
	else if(myState == States.sheets_1)		{sheets_1();}
	else if(myState == States.corridor_0)	{corridor_0();}
	}
	void cell(){
		text.text = "You are in the prison and want to escape. " +
					"There are some dirty sheets on the bed, a mirror " +
					"on the wall and the doors, that are locked. \n\n" +
					"Press M to look at Mirror, S for Sheets and L to look on the Locked doors";
		if(Input.GetKeyDown(KeyCode.S))			{myState = States.sheets_0;}
		if(Input.GetKeyDown(KeyCode.M))			{myState = States.mirror;}
		if(Input.GetKeyDown(KeyCode.L))			{myState = States.lock_0;}
	}
	void sheets_0(){
		text.text = "Some disgusting, terrible sheets." +
					"You can't believe you sleep in these." +
					"There's nothing more you can do. \n\n" +
					"Press R to Return to your cell";
		if(Input.GetKeyDown(KeyCode.R))			{myState = States.cell;}
	}
	void lock_0(){
		text.text = "One of the typical locks in the prison door. " +
					"You have no idea how to open it. \n\n" +
					"Press R to Return to your cell";
		if(Input.GetKeyDown(KeyCode.R))			{myState = States.cell;}
	}
	void lock_1(){
		text.text = "With a bit of luck you will be able to " +
					"slide a piece of the mirror into the lock and turn it to open the cell. \n\n" +
					"Press O to Open, R to Return to your cell";
		if(Input.GetKeyDown(KeyCode.R))			{myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.O))	{myState = States.corridor_0;}
	}
	void mirror(){
		text.text = "Old, dirty mirror on the wall. " +
					"There is one loose shard, which you can take. \n\n" +
					"Press T to Take, R to Return to your cell";
		if(Input.GetKeyDown(KeyCode.R))			{myState = States.cell;}
		else if (Input.GetKeyDown(KeyCode.T))	{myState = States.cell_mirror;}
	}
	void sheets_1(){
		text.text = "Holding this shard doesn't even matter " +
					"when you look at the sheets." +
					"They are still terribly disgusting. \n\n" +
					"Press R to Return to your cell";
		if(Input.GetKeyDown(KeyCode.R))			{myState = States.cell_mirror;}
	}
	void cell_mirror(){
		text.text = "You have a part of the mirror, what you gonna do next? " +
					"Maybe you should try to escape as fast as possible! \n\n" +
					"Press S to view Sheets, L to view Lock";
		if(Input.GetKeyDown(KeyCode.S))			{myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L))	{myState = States.lock_1;}
	
	
}
	void corridor_0(){
		text.text = "You are in a corridor. \n\n" +
					"Press P to Play again";
		if(Input.GetKeyDown(KeyCode.P))			{myState = States.cell;}
}
}