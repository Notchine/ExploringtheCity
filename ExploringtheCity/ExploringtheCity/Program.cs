using System;
using System.Linq;
using System.Threading;
using System.Collections;

public class Program
{
	Random rand;

	public static string yourePoor = "You can't afford this item.";
	public static bool IsRunning = true;
	//public static string[] inventory = new string[10];
	public static ArrayList inventory2 = new ArrayList();
	public static bool thiefSpawn = true;
	public static bool blackMarketKnowledge = false;
	public struct Player
	{
		public int PlayerHealth;
		public int PlayerMaxHP;
		public int PlayerDef;
		public int PlayerAttack;
		public int LVL;
		public int EXPToNextLVL;
		public int EXP;
		public int Gold;
	}
	#region levelling
	//	void LevelUp()
	//    {
	//		Player.level++
	//			Player.xp = 0
	//levelling shit

	//		{ex limit} *= 1.2
	//increases required exp for each level by 20%
//}
#endregion
public static Player p1;

	public struct Enemy
	{
		public string EnemyName;
		public int EnemyMaxHP;
		public int EnemyHealth;
		public int EnemyAttack;
		public int EnemyEXP;
		public int EnemyGold;
	}
	public static Enemy thief;
	public static Enemy drugAddict;
	public static Enemy giantRat;


	public struct Weapon
	{
		#region weapon data
		public int id;
		public string weaponName;
		public string weaponInfo { get; set; }
		public int Dmg { get; set; }
		public int critChance { get; set; }
		#endregion
	}
	public static Weapon CrackedBaton;
	public static Weapon Handgun;
	public static Weapon Uzi;

	static public string deathText = "You have now DIED. X_X";
    public static void Combat(Enemy enemy)
	{
		Console.WriteLine("Enemy encountered! You have been attacked by the " + enemy.EnemyName);
		Thread.Sleep(2000);
		while (p1.PlayerHealth > 0)
		{
			if (enemy.EnemyHealth <= 0)
			{
				Console.WriteLine("Enemy Defeated!");
				Console.WriteLine("");
				p1.EXP += enemy.EnemyEXP;
				Console.WriteLine("Earned EXP: "+ enemy.EnemyEXP);
				Console.WriteLine("Earned Gold: " + enemy.EnemyGold);
				Console.WriteLine("Total Gained Experience: "+ p1.EXP);
				Console.WriteLine("EXP to next level: " + p1.EXPToNextLVL);
				//write Exp earned and whether they level up maybe
				enemy.EnemyHealth = +enemy.EnemyMaxHP;
				break;
			}
			else
			{
				enemy.EnemyHealth -= p1.PlayerAttack;
				Console.WriteLine("Reamining Enemy HP: " + enemy.EnemyHealth);
				Thread.Sleep(500);

				p1.PlayerHealth -= enemy.EnemyAttack;
				Console.WriteLine("Remaining Player HP: " + p1.PlayerHealth);
				Thread.Sleep(500);


				if (p1.PlayerHealth <= 0)
				{
					Console.WriteLine(deathText);
					Thread.Sleep(2500);
					//end game or take the player elsewhere
					p1.PlayerHealth += +5;
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
		Console.WriteLine("You are standing in a dark alley with no real recollection of how you got there. There is a faint smell of oil and old garbage surrounding you. The only exit you can see if the opening at the end of the alleyway which shines with bright, blinding streetlights.");
		Console.WriteLine(" ");
		//player options
		Console.WriteLine("1. Walk out the alleyway");
		Console.WriteLine("2. Stay in the alleyway");
		Console.WriteLine(" ");
		//user input
		int input = Convert.ToInt32(Console.ReadLine());

		//		string rawInput;
		//		do
		//		{
		//			 rawInput = Console.ReadLine();
		//		}
		//		while (Int32.TryParse(rawInput, out _));
		//		int input = int.Parse(rawInput);
		//condition check to move rooms
		switch (input)
		{
			case 1:
				Console.WriteLine("You decide to exit the alleyway as there is no reason for you to remain here.");
				IsRunning = false;
				if (thiefSpawn == true)
				{
					Console.WriteLine("Suddenly, you notice shifting movements in the corner of your eye from the shadows!");
					Console.WriteLine();
					Thread.Sleep(1500);
					Combat(thief);
					thiefSpawn = false;
					Console.WriteLine("After narrowly surviving the encounter with the thief, you quickly exit the cramped alleyway.");
					Console.WriteLine();
					Thread.Sleep(4000);
					Room1();
				}
				else if (thiefSpawn == false)
				{
					Room1();
				}
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
		Console.WriteLine(" ");
		Console.WriteLine("You are now standing in the middle of the busy sidewalk of the city, the faceless crowd pushing and shoving past you. You notice a PECULIAR LOCKED BOX chained shut which has a small keyhole in front.");
		Console.WriteLine(" ");
		//player options
		Console.WriteLine("1. Investigate the PECULIAR LOCKED BOX");
		Console.WriteLine("2. Return to the alleyway");
		Console.WriteLine("3. Continue down the street.");
		Console.WriteLine(" ");

		//user input
		int input = Convert.ToInt32(Console.ReadLine());
			//condition check to move rooms
			switch (input)
			{
				case 1:
					if (inventory2.Contains("Small Key"))
					{
						Console.WriteLine("After unlocking the PECULIAR LOCKED BOX, the oversized padlock as well as the chains tightly wrapped around it thud to the ground, generating a sound so loud it could be heard even beyond the sounds of the bustling city streets.");

						Console.WriteLine("After opening the PECULIAR LOCKED BOX, you discover the SMALL CRACKED BATON and place it into your inventory. You also throw the SMALL KEY away, as you doubt you'll get much usage out of it anymore.");
						inventory2.Add("Small Cracked Baton");
					Room1();
					}
					else
					{
						Console.WriteLine("It seems to be chained shut and cannot be opened right now.");
						Console.WriteLine();
						Room1();
					}
					break; //breaks out of this entire case, moving  on the next part of da code
				case 2:
					Console.WriteLine("You turn around and begin walking towards the alleyway you were previously in.");
					StartingRoom();
					break;
				case 3:
					Console.WriteLine("You make your way down the city streets...");
					Room2();
					break;
				default:
					Console.WriteLine("Invalid entry, try again.");
					break;
			}
		}

	public static void Room2()
	{
		//description of room
		Console.WriteLine(" ");
		Console.WriteLine("You are now in the shopping district. This place seems even more bustling than the city streets, with even more people rushing past you as you try to find your way through the densely packed hoard.");
		Console.WriteLine(" ");
		//player options
		Console.WriteLine("1. Walk to the city streets");
		Console.WriteLine("2. Walk to the train station");
		Console.WriteLine("3. Enter the store");
		Console.WriteLine(" ");
		//codeword for entering black market is "the stallion is shiny" ACTUALLY NO THIS IS DUMB JUST HAVE IT BE ENABLED BY BEATING THE DUDES IN THE ABANDONED SCHOOL I KNOW YOU CAN JUST HAVE IT CHECK FOR A SPECIFIC STATEMENT BUT A BOOLEAN IS INFINITELY EASIER YOU DUMMY
		//use different switches, one for before you discover the black market and one for after. Use a static boolean and set it to true when youre ready to enter the black market.
		if (blackMarketKnowledge == false)
		{
			//user input
			int input = Convert.ToInt32(Console.ReadLine());
			//condition check to move rooms
			switch (input)
			{
				case 1:
					Console.WriteLine("You make your way back to the city streets...");
					Room1();
					break; //breaks out of this entire case, moving  on the next part of da code
				case 2:
					Console.WriteLine("You make your way to the train station...");
					Room3();
					break;
				case 3:
					Console.WriteLine("You approach the store door, push it open, and begin to speak with the cashier...");
					Room4();
					break;
				default:
					Console.WriteLine("Invalid entry, try again.");
					break;
			}
		}
		else if (blackMarketKnowledge == true)
		{
			Console.WriteLine("4. Descend to the black market");
			//user input
			int input = Convert.ToInt32(Console.ReadLine());
			//condition check to move rooms
			switch (input)
			{
				case 1:
					Console.WriteLine("You make your way back to the city streets...");
					Room1();
					break; //breaks out of this entire case, moving  on the next part of da code
				case 2:
					Console.WriteLine("You make your way to the train station...");
					Room3();
					break;
				case 3:
					Console.WriteLine("You approach the store door, push it open, and begin to speak with the cashier...");
					break;
				case 4:
					Console.WriteLine("You carefully step through a secluded entrance you previously did not notice, descending deeper into the shopping district away from the bustling humanity behind you...");
					Room8(); //this is gonna be the black market
					break;
				default:
					Console.WriteLine("Invalid entry, try again.");
					break;
			}
		}
	}
	public static void Room3()
	{
		//description of room
		Console.WriteLine(" ");
		Console.WriteLine("You are now in the train station. The large gathering of people outside seem to all be attempting to squeeze themselves in behind you, attempting to catch the train as quickly as possible. From here, you can either exit back into the shopping district, take the train to the park or take the train to the abandoned school.");
		Console.WriteLine(" ");

		//player options
		Console.WriteLine("1. Exit to the shopping district");
		Console.WriteLine("2. take the train to the park");
		Console.WriteLine("3. take the train to the abandoned school");
		Console.WriteLine(" ");
		//user input
		int input = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (input)
		{
			case 1:
				Console.WriteLine("You make your way back to the shopping district...");
				Room2();
				//Thread.Sleep(2000);
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				Console.WriteLine("You make your way park...");
				break;
			case 3:
				Console.WriteLine("You make your way back to the abandoned park...");
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
	}
	public static void Room4()
	{
		//description of room
		Console.WriteLine(" ");
		Console.WriteLine("You are now in the store. This shop is mostly empty, besides the singular shopkeeper who welcomes you with a smile and suggests that you take a thorough glance through his wares for anything that peeks your interest.");
		Console.WriteLine(" ");

		//player options	
		Console.WriteLine("(Select which item you wish to purchase before selecting the last option to exit the store.)");
		Console.WriteLine("*SHOP INVENTORY*");

		Console.WriteLine("1. Nail Bat - 50 Gold");
		Console.WriteLine("2. Military Helmet - 40 Gold");
		Console.WriteLine("3. Small Key - 70 Gold");
		Console.WriteLine();
		Console.WriteLine("");
		//user input
		int input = Convert.ToInt32(Console.ReadLine());
        //condition check to move rooms
        #region shop item stuff
        switch (input)
		{
			case 1:
				if (p1.Gold >= 50)
				{
					p1.Gold -= 50;
					inventory2.Add("Nail Bat");
					Console.WriteLine("You have purchased the Nail Bat. You Equip it immediately. ATK increased by 10");
					p1.PlayerAttack += 10;
					Console.Write("Inventory Contents: ");
					{
						foreach (Object obj in inventory2)
							Console.Write("   {0}", obj);
						Console.WriteLine();
					}
					Console.ReadLine();
					Room4();
				}
				else
                {
					Console.WriteLine(yourePoor);
					Room4();
				}
				//Thread.Sleep(2000);
				break; //breaks out of this entire case, moving  on the next part of da code
			case 2:
				if (p1.Gold >= 40)
				{
					p1.Gold -= 40;
					inventory2.Add("Military Helmet");
					Console.WriteLine("You have purchased the Military Helmet. You Equip it immediately. DEF increased by 15");
					p1.PlayerDef += 15;
					Console.Write("Inventory Contents: ");
					{
						foreach (Object obj in inventory2)
							Console.Write("   {0}", obj);
						Console.WriteLine();
					}
					Console.ReadLine();
					Room4();
				}
				else
				{
					Console.WriteLine(yourePoor);
					Room4();
				}
				break;
			case 3:
				if (p1.Gold >= 70)
				{
					p1.Gold -= 70;
					inventory2.Add("Small Key");
					Console.WriteLine("You have purchased the Small Key. You shove the cold, slightly rusted key into your pocket as the shopkeeper gives you a false, plastered on grin after you've handed him your money. ");
					Console.WriteLine("");
					Console.Write("Inventory Contents: ");
					{
						foreach (Object obj in inventory2)
							Console.Write("   {0}", obj);
						Console.WriteLine();
					}
					Console.ReadLine();
					Room4();
				}
				else
				{
					Console.WriteLine(yourePoor);
					Room4();
				}
				break;
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
        #endregion
    }
    public static void Room5()
	{
		//description of room
		Console.WriteLine("");
		Console.WriteLine("You are now standing in a disgusting sewer. There is an overwhelmingly horrid stench filling the area and scittering can be heard in all directions...");
		Console.WriteLine("");
		Thread.Sleep(5000);
		Console.WriteLine("Suddenly, the skittering grows louder and louder until you are face to face with a colossal figure. It seems to be some sort of gigantic rat, it's body covered in countless calluses, dried blood splatters, scars and scabs. Seems like it sees you as nothing more than another meal...");
		Console.WriteLine("");
		Thread.Sleep(7000);
		Combat(giantRat);

		p1.PlayerAttack += 10;
		p1.PlayerDef += 10;
		Console.WriteLine("");
		Console.WriteLine("The rat lets out a cacophonic screech before collapsing to the ground, cold and lifeless. As you approach the fresh corpse, still unsure of your safety after this battle, you notice a mysterious briefcase wedged in an unusual viscous pile which catches your attention instantly. Without a second thought, you open the briefcase, revealing a syringe containing a strange, glowing liquid. 'Looks interesting, might help out.' After injecting yourself in an attempt to get as much of an edge against any enemies as possible, you feel a deep, powerful energy filling your body as you nearly faint from the sensation. Your ATK and DEF have both increased by 10. Nothing else to do here, now.");

		//player options
		Console.WriteLine("1. Climb out of a nearby manhole");
		//user input
		int input = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (input)
		{
			case 1:
				Console.WriteLine("You proceed to locate and exit through a nearby manhole, pushing the heavy cover asside and emerging onto the city streets once again...");
				Room1();
				//Thread.Sleep(2000);
				break; //breaks out of this entire case, moving  on the next part of da code
			default:
				Console.WriteLine("Invalid entry, try again.");
				break;
		}
	}
	public static void Room6()
	{
		//description of room
		Console.WriteLine("You are now in the park. This place is practically a nesting ground for thieves who crave upon the innocents who walk past this park. What will you do?");

		//player options
		Console.WriteLine("1. Fight thieves");
		Console.WriteLine("2. Return to the train station");
		//user input
		int input = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (input)
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
		int input = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (input)
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
		int input = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (input)
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
		int input = Convert.ToInt32(Console.ReadLine());
		//condition check to move rooms
		switch (input)
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
		p1.PlayerMaxHP = 10;
		p1.PlayerDef = 0;
		p1.LVL = 1;
		p1.EXP = 0;
		p1.EXPToNextLVL = 5;
		p1.Gold = 999;

		//enemy stats
		//thief
		thief.EnemyName = "thief";
		thief.EnemyAttack = 1;
		thief.EnemyHealth = 4;
		thief.EnemyMaxHP = 4;
		thief.EnemyEXP = 3;
		thief.EnemyGold = 4;
		//drug addict
		drugAddict.EnemyName = "Drug Addict";
		drugAddict.EnemyAttack = 2;
		drugAddict.EnemyHealth = 6;
		drugAddict.EnemyMaxHP = 6;
		drugAddict.EnemyEXP = 5;
		drugAddict.EnemyGold = 7;
		//DA GIANT EVIL ENEMY RAT!!!!!!!!!!!!!!
		giantRat.EnemyName = "The Giant Rat";
		giantRat.EnemyAttack = 5;
		drugAddict.EnemyHealth = 50;
		drugAddict.EnemyMaxHP = 50;
		drugAddict.EnemyEXP = 100;
		drugAddict.EnemyGold = 150;
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

					