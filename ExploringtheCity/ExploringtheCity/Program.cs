using System;
using System.Linq;
using System.Threading;
using System.Collections;

public class Program
{

	public static bool IsRunning = true;
	//public static string[] inventory = new string[10];
	public static ArrayList inventory2 = new ArrayList();

	public struct Player
	{
		public int PlayerHealth;
		public int PlayerAttack;
		public int LVL;
		public int EXPToNextLVL;
		public int EXP;
	}
	public static Player p1;

	public struct Enemy
	{
		public string EnemyName;
		public int EnemyHealth;
		public int EnemyAttack;
	}
	public static Enemy thief;
	public static Enemy drugAddict;

	struct Weapon
	{
		#region weapon data
		public int id;
		public string weaponName;

		public int Dmg { get; set; }

		public int critChance { get; set; }

		public string weaponInfo { get; set; }

		public int[] attacks;
		#endregion
	}
	static public string deathText = "You have now DIED. X_X";
    public static void Combat(Enemy enemy)
	{
		Console.WriteLine("Enemy encountered! You have been attacked by the " + enemy.EnemyName);

		while (p1.PlayerHealth > 0)
		{
			if (enemy.EnemyHealth <= 0)
			{
				Console.WriteLine("Enemy Defeated!");
				//write Exp earned and whether they level up maybe
				break;
			}
			else
			{
				enemy.EnemyHealth -= p1.PlayerAttack;
				Console.WriteLine("Reamining Enemy HP: " + enemy.EnemyHealth);
				p1.PlayerHealth -= enemy.EnemyAttack;
				Console.WriteLine("Remaining Player HP: " + p1.PlayerHealth);

				if (p1.PlayerHealth <= 0)
				{
					Console.WriteLine(deathText);
					Thread.Sleep(2500);
					//end game or take the player elsewhere
					p1.PlayerHealth =+ +5;
					StartingRoom();					
					//IsRunning = false;
					break;
				}
			}

		}
	}

	public static void StartingRoom()
	{

		
		//description of room
		Console.WriteLine("You awaken in a dark alley with no recollection of how you got there. There is a faint smell of oil and old garbage surrounding you. The only exit you can see if the opening at the end of the alleyway which shines with bright, blinding streetlights.");

		//player options
		Console.WriteLine("1. Walk out the alleyway");
		Console.WriteLine("2. Stay in the alleyway");

		//user input
		int imput = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (imput)
		{
			case 1:
				Console.WriteLine("You decide to exit the alleyway as there is no reason for you to remain here.");
				Console.WriteLine("Suddenly, you notice shifting movements in the corner of your eye from the shadows!");
				IsRunning = false;
				Combat(thief);
				Thread.Sleep(2000);
				Room1();
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				Console.WriteLine("Nothing happens as you stand idly in the alleyway.");
				StartingRoom();
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				//send them to same room they are in
				StartingRoom();
				break;
		}
	}
	public static void Room1()
	{


		//description of room
		Console.WriteLine("You are now standing in the middle of the busy sidewalk of the city, the faceless crowd pushing and shoving past you. You notice a PECULIAR LOCKED BOX chained shut which has a small keyhole in front.");

		//player options
		Console.WriteLine("1. Investigate the PECULIAR LOCKED BOX");
		Console.WriteLine("2. Return to the alleyway");
		Console.WriteLine("3. Continue down the street.");

		//user input
		int imput = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (imput)
		{
			case 1:
				if (inventory2.Contains("Small Key")) 
				{
					Console.WriteLine("After unlocking the PECULIAR LOCKED BOX, the oversized padlock as well as the chains tightly wrapped around it thud to the ground, generating a sound so loud it could be heard even beyond the sounds of the bustling city streets.");

					Console.WriteLine("After opening the PECULIAR LOCKED BOX, you discover the SMALL CRACKED BATON and place it into your inventory. You also throw the SMALL KEY away, as you doubt you'll get much usage out of it anymore.");
					inventory2.Add("Small Cracked Baton");
				}
				Room1();
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				Console.WriteLine(deathText);
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
	}
	public static void Room2()
	{
		//description of room
		Console.WriteLine("room2 text");

		//player options
		Console.WriteLine("1. Use the Key");
		Console.WriteLine("2. Walk further down the street");
		Console.WriteLine("3. Return to the alleyway");
		//user input
		int imput = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (imput)
		{
			case 1:
				Console.WriteLine("You attempt to use the key...");
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				Console.WriteLine(deathText);
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
	}
	public static void Room3()
	{
		//description of room
		Console.WriteLine("");

		//player options
		Console.WriteLine("1. ");
		Console.WriteLine("2. ");
		Console.WriteLine("3. ");
		//user input
		int imput = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (imput)
		{
			case 1:
				Console.WriteLine("");
				//Thread.Sleep(2000);
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				Console.WriteLine("");
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
	}
	public static void Room4()
	{
		//description of room
		Console.WriteLine("");

		//player options
		Console.WriteLine("1. ");
		Console.WriteLine("2. ");
		Console.WriteLine("3. ");
		//user input
		int imput = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (imput)
		{
			case 1:
				Console.WriteLine("");
				//Thread.Sleep(2000);
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				Console.WriteLine("");
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
	}
	public static void Room5()
	{
		//description of room
		Console.WriteLine("");

		//player options
		Console.WriteLine("1. ");
		Console.WriteLine("2. ");
		Console.WriteLine("3. ");
		//user input
		int imput = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (imput)
		{
			case 1:
				Console.WriteLine("");
				//Thread.Sleep(2000);
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				Console.WriteLine("");
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
	}
	public static void Room6()
	{
		//description of room
		Console.WriteLine("");

		//player options
		Console.WriteLine("1. ");
		Console.WriteLine("2. ");
		Console.WriteLine("3. ");
		//user input
		int imput = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (imput)
		{
			case 1:
				Console.WriteLine("");
				//Thread.Sleep(2000);
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				Console.WriteLine("");
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
	}
	public static void Room7()
	{
		//description of room
		Console.WriteLine("");

		//player options
		Console.WriteLine("1. ");
		Console.WriteLine("2. ");
		Console.WriteLine("3. ");
		//user input
		int imput = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (imput)
		{
			case 1:
				Console.WriteLine("");
				//Thread.Sleep(2000);
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				Console.WriteLine("");
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
	}
	public static void Room8()
	{
		//description of room
		Console.WriteLine("");

		//player options
		Console.WriteLine("1. ");
		Console.WriteLine("2. ");
		Console.WriteLine("3. ");
		//user input
		int imput = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (imput)
		{
			case 1:
				Console.WriteLine("");
				//Thread.Sleep(2000);
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				Console.WriteLine("");
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
	}
	public static void Room9()
	{
		//description of room
		Console.WriteLine("");

		//player options
		Console.WriteLine("1. ");
		Console.WriteLine("2. ");
		Console.WriteLine("3. ");
		//user input
		int imput = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (imput)
		{
			case 1:
				Console.WriteLine("");
				//Thread.Sleep(2000);
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				Console.WriteLine("");
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
	}

	public static void Main()
	{
		//player stats
		p1.PlayerAttack = 2;
		p1.PlayerHealth = 10;
		p1.LVL = 1;
		p1.EXP = 0;
		p1.EXPToNextLVL = 5;

		//enemy stats
		thief.EnemyName = "thief";
		thief.EnemyAttack = 1;
		thief.EnemyHealth = 4;
		drugAddict.EnemyAttack = 2;
		drugAddict.EnemyHealth = 6;

		//index of all items in the game

		//inventory[0] = "Small Key";
		//inventory[1] = "Pistol";
		//inventory[2] = "Moldy Burger";
		//inventory[3] = "Small Cracked Batton";

		bool IsRunning = true;
		while (IsRunning == true)
		{
			StartingRoom();
		}

	}
}
//inventory2.Add("itemName");
//inventory2.Remove("itemName");
//if (inventory2.Contains("")) { }

					