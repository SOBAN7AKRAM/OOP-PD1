using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;

namespace Game
{
    class Program
    {
        // variables for counting score,player and enemy health etc
        static int score = 0, count = 15, horizontalCount = 15, followCount = 20, playerhealth = 30, VEH = 15, HEH = 15, FEH = 20;
        static int bulletCount = 0, bulletCountV = 0, bulletCountH = 0;
        // variable for moving ghost 
        static string direction = "down";
        static string horizontalDirection = "left";
        static string followStatus = "isAlive";
        static char[,] array = new char[,]
        {
            {'%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','%'},
            {'%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%','%'} 
        };

        static void Main(string[] args)
        {
            //variables to positioning player on console
            int px = 12, py = 16;
            //variables to positioning enemies on console
            int vgx = 68, vgy = 8, hgx = 10, hgy = 22, fgx = 56, fgy = 6;
            //variables to slow down the speed of ghost and timerB for bullet
            int timerV = 2, timerH = 2, timerF = 2, timerB = 2;

            //to store answer from detect collission function
            bool result;

            //arrays to store bullet
            int[] bulletX = new int[10000];
            int[] bulletY = new int[10000];
            int[] bulletVY = new int[10000];
            int[] bulletVX = new int[10000];
            int[] bulletHX = new int[10000];
            int[] bulletHY = new int[10000];

            //arrays to store active bullet
            bool[] isBulletActive = new bool[10000];
            bool[] isBulletActiveVertical = new bool[10000];
            bool[] isBulletActiveHorizontal = new bool[10000];

            // variables to print character used in printing player and enemy

            char p = (char)148;
            char l = (char)240;
            char g = (char)219;
            char a = (char)162;
            char b = (char)229;

            //2D array to print player
            char[,] player = new char[,]
            {
                { ' ', p, ' ' },
                { '(', l, ')' },
                { '/', ' ', '\\' }
             };
            //2D array to print vertical ghost
            char[,] verticalGhost = new char[,]
                {
                   { ' ','@',' '},
                   { '(',g,')'},
                   { '/',' ','\\'}
                };
            //2D array to print horizontal ghost 
            char[,] horizontalGhost = new char[,]
                {
                   { ' ',a,' '},
                   { '{',g,'}'},
                   { '<',' ','>'}
                };
            //2D array to print follow ghost
            char[,] followGhost = new char[,]
                {
                   { ' ',b,' '},
                   { '[',g,']'},
                   { '=',' ','='}
                };

            //calling function to print logo and opening menu

            Console.Clear();
            logo();
            loading();
            Console.Clear();
            loginMenuHeader();
            Console.WriteLine("\n\n\n");
            menu();
            //variables to store users option for main menu and optional menu
            int option, keyoption, choice = 3;
            bool gamerunning = true;
            while (gamerunning)
            {
                Console.WriteLine("Enter Your Option:");
                option = int.Parse(Console.ReadLine());
                if (option == 1 || option == 2)
                {
                    if (option == 2)
                    {
                        // calling function to read data from file
                       //readData(px, py, fgx, fgy, vgx, vgy, hgx, hgy);
                       //readBullet(bulletX, bulletY, bulletVX, bulletVY, bulletHX, bulletHY);
                       //option = 1;
                    }
                    //calling function to start the game
                    Console.Clear();
                     printMaze();
                     printPlayer(player,ref px,ref py);
                     printVerticalGhost(verticalGhost,ref vgx,ref vgy);
                    // printHorizontalGhost(horizontalGhost, hgx, hgy);
                    // printFollowGhost(followGhost, fgx, fgy);
                    //loop for game running
                    while(true)
                    {
                        //functions to print health and score
                        playerHealth();
                        printScore();
                        verticalEnemyHealth();
                        //followEnemyHealth();
                        //horizontalEnemyHealth();
                        //result = detectCollision(px, py, fgx, fgy);
                        //condition to check wheter player is die or won the game
                        //if (playerhealth <= 0 || result == true || score >= 50)
                        //{
                        //    system("cls");
                        //    if (playerhealth <= 0 || result == true)
                        //    {
                        //        YouDie();
                        //        Sleep(1000);
                        //    }
                        //    else if (score >= 50)
                        //    {
                        //        YouWon();
                        //        Sleep(1000);
                        //    }
                        //
                        //    system("cls");
                        //    loginMenuHeader();
                        //    cout << endl << endl << endl;
                        //    menu();
                        //initializing variables to initial values so that new game will start 
                        // playerhealth = 30;
                        // score = 0;
                        // fgx = 56, fgy = 6;
                        // px = 12, py = 16;
                        // vgx = 68, vgy = 8, hgx = 10, hgy = 22,count = 15,horizontalCount = 15,followCount = 20,VEH = 15,HEH = 15,FEH = 20,timerV = 2,timerH = 2,timerF = 2,timerB = 2;
                        // followStatus = "isAlive";
                        // break;
                        //}
                        //read keys from console to move player
                        if (Keyboard.IsKeyPressed(Key.RightArrow))
                        {
                            moveright(player,ref px,ref py);
                        }
                        if (Keyboard.IsKeyPressed(Key.LeftArrow))
                        {
                            moveleft(player,ref px,ref py);
                        }
                        if (Keyboard.IsKeyPressed(Key.UpArrow))
                        {
                            moveup(player,ref px,ref py);
                        }
                        if (Keyboard.IsKeyPressed(Key.DownArrow))
                        {
                            movedown(player,ref px,ref py);
                        }
                        if (Keyboard.IsKeyPressed(Key.Space))
                        {
                            //to fire bullets of player
                            char nextlocation = getCharatxy(px + 3, py);
                            if (nextlocation != '%')
                            {
                                generateBullet(bulletX, bulletY, isBulletActive,ref px,ref py);
                            }
                        }
                        // timer to slow down the vertical ghost
                        if (timerV == 2)
                        {
                            //count varibles to remove ghost if health is 0
                            if (count > 0)
                            {
                                moveVerticalGhost(verticalGhost,ref vgx,ref vgy);
                      
                                timerV = 0;
                            }
                            if (count <= 0)
                            {
                                removeVerticalGhost(ref vgx,ref vgy);
                            }
                        }
                        if (count > 0)
                        {
                            if (timerB == 2)
                            {
                                generateBulletV(bulletVX, bulletVY, isBulletActiveVertical,ref vgx,ref vgy);
                                timerB = 0;
                            }
                        }

                        //calling functions to move bullets of enemy and player
                        moveBulletV(bulletVX, bulletVY, isBulletActiveVertical);
                        moveBullet(bulletX, bulletY, isBulletActive);
                        //calling functions to detect bullet collision with enemy and player
                        bulletCollisionWithVerticalEnemy(bulletX, bulletY, isBulletActive);


                        timerV++;
                        timerB++;
                        System.Threading.Thread.Sleep(100);


                    }

                }

                //if options 3 to open key detail and instruction menu
                if (option == 3)
                {
                    options();
                    while (true)
                    {
                        Console.WriteLine("Enter your option:");
                        keyoption = int.Parse(Console.ReadLine());
                        if (keyoption == 1)
                        {
                            keysDetail();
                            Console.WriteLine("Press any Key to continue:");
                            Console.ReadKey();
                            options();
                        }
                        if (keyoption == 2)
                        {
                            instruction();
                            Console.WriteLine("Press any key to continue:");
                            Console.ReadKey();
                            options();
                        }
                        if (keyoption == 3)
                        {
                            Console.Clear();
                            loginMenuHeader();
                            Console.WriteLine("\n\n\n");
                            menu();
                            break;
                        }
                        else if (keyoption == 0 || keyoption > 3)
                        {
                            Console.WriteLine("INVALID OPTIONS");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            options();
                        }
                    }
                }
                //conditions to close the game
                if (option == 4)
                {
                    return;
                }
                //condition to check invalid options
                else if (option == 0 || option > 4)
                {
                    Console.WriteLine("INVALID OPTIONS");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    loginMenuHeader();
                    Console.WriteLine("\n\n\n");
                    menu();
                }
            }

        }

    
        static void logo()
        {
            Console.WriteLine("                                    .-==-=-.                    ");
            Console.WriteLine("                                   -*==. :=*=                   ");
            Console.WriteLine("                                   .#========#.                 ");
            Console.WriteLine("                                   #+++==++*#                   ");
            Console.WriteLine("                                   :##**=++*+----.              ");
            Console.WriteLine("                                :---:.           .---.          ");
            Console.WriteLine("                             .=-.                    :=         ");
            Console.WriteLine("                            :=           ...::::-*@+. .+        ");
            Console.WriteLine("                           .+  .%#*+======----*%@#+-=: --       ");
            Console.WriteLine("                           =. :+++*@%#*......==+*:...:  +       ");
            Console.WriteLine("                           =. :....%:..........-%.....: =.      ");
            Console.WriteLine("                           -: :....#=:..........@%....- ::       " );
            Console.WriteLine("                           .= :....=@+..........#@....- :=        ");
            Console.WriteLine("                            * .:....@%..........+@-...- :-        ");
            Console.WriteLine("                            =: -....#@:.........=@+..:: +.        ");
            Console.WriteLine("                             +  :...=@+.........:*=::. --         ");
            Console.WriteLine("                              +. .:::+-....:::::.....-+:          ");
            Console.WriteLine("                               -=-...:::::.....:::-==:            ");
            Console.WriteLine("                               .-+-:---======+++++*+-             ");
            Console.WriteLine("                               *  .+==*#*+*###%==+=*:+.           ");
            Console.WriteLine("                               .=- .==+##%%%%%%+===*%+.           ");
            Console.WriteLine("                                 :*--:=*%%#**+++++++**-.          ");
            Console.WriteLine("                                .*+=.  :=++++++++++++. *-         ");
            Console.WriteLine("                                =*===-====*++++++++**-==*         ");
            Console.WriteLine("                                :#*+++==++=-+*******+++*+         ");
            Console.WriteLine("                                 :*#***##:   ##*=: =##*-          ");
            Console.WriteLine("                                   :--+-   :=:+   =:             " );
            Console.WriteLine("                                     -=   .+  *.  --             " );
            Console.WriteLine("                                    :+    *   *.  --             " );
            Console.WriteLine("                                    .*    +.   *.  --             ");
            Console.WriteLine("                                   .*    -:   .+   =:             ");
            Console.WriteLine("                                -+*++==::=    ++.:-+*+=-.         ");
            Console.WriteLine("                              :*+=======++.  #*=========++=-      ");
            Console.WriteLine("                             -#+====-::-==* +*+=========-::-*=    ");
            Console.WriteLine("                             %+=====:..:=+# #*+=========:..:=++   ");
            Console.WriteLine("                             #***+++++***#- -+****************.   ");
            Console.WriteLine("                             ..:::::::..                         ");
        }
        static void loading()
        {
            Console.WriteLine("                                    LOADING");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine( ".");
                System.Threading.Thread.Sleep(200);
            }
        }
        static void loginMenuHeader()
        {
            Console.WriteLine(" _____  _              _____             ");
            Console.WriteLine("|   __||_| ___  ___   |     | ___  ___   ");
            Console.WriteLine("|   __|| ||  _|| -_|  | | | || .'||   |  ");
            Console.WriteLine("|__|   |_||_|  |___|  |_|_|_||__,||_|_|  ");
        }
        static void menu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("----------------");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Resume Game");
            Console.WriteLine("3. Option");
            Console.WriteLine("4. Exit");
        }
        static void options()
        {
            Console.Clear();
            loginMenuHeader();
            Console.WriteLine("\n\n");
            Console.WriteLine("OPTION MENU");
            Console.WriteLine("-----------------");
            Console.WriteLine("1. Keys");
            Console.WriteLine("2. Instruction");
            Console.WriteLine("3. Exit");
        }
        static void keysDetail()
        {
            Console.Clear();
            loginMenuHeader();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("KEYS DETAIL");
            Console.WriteLine("-----------------");
            Console.WriteLine("UP\t\tGo Up");
            Console.WriteLine("DOWN\t\tGo Down");
            Console.WriteLine("LEFT\t\tGo Left");
            Console.WriteLine("RIGHT\t\tGo Right");
            Console.WriteLine("D\t\tFire");
            Console.WriteLine("ESCAPE\t\tExit Game");
        }
        static void instruction()
        {
            Console.Clear();
            loginMenuHeader();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("INSTRUCTIONS");
            Console.WriteLine("------------------");
            Console.WriteLine("Player will fire on right side by pressind 'D' key.");
            Console.WriteLine("Score will add when bullet interact with enemy");
            Console.WriteLine("Player health will decrease when enemy bullet collide with player");
            Console.WriteLine("Player will die if it collide with follow ghost");
            Console.WriteLine("Player will won the game if you score 50");
        }
        static void printMaze()
        {
            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write( array[i, j]);
                }
                Console.WriteLine();
            }

        }
        static void printPlayer(char[,] player,ref int px,ref int py)
        {
            for (int i = 0; i < 3; i++)
            {
                gotoxy(px, py + i);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}",player[i,j]);
                }
                Console.WriteLine();
            }
        }
        static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x,y);
        }
        static void printVerticalGhost(char[,] verticalGhost,ref int vgx,ref int vgy)
        {
            for (int i = 0; i < 3; i++)
            {
                gotoxy(vgx, vgy + i);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}",verticalGhost[i,j]);
                }
                Console.WriteLine();
            }
        }
        static void playerHealth()
        {
            gotoxy(80, 10);
            Console.Write("PLAYER HEALTH:{0}",playerhealth);
        }
        static void printScore()
        {
            gotoxy(80, 8);
            Console.Write("Score:{0}", score);
        }
        static void addScore()
        {
            score++;
        }
        static void verticalEnemyHealth()
        {
            gotoxy(80, 12);
            Console.Write("Vertical Enemy Health:{0}",count);
        }
        static void moveright(char[,] player, ref int px,ref int py)
        {
            
            if (array[py,px+3]==' ' && array[py+1,px+3]==' ' && array[py+2,px+3]==' ' )
            {
                
                gotoxy(px, py);
                removeplayer(ref px,ref py);
                px = px + 1;
                gotoxy(px, py);
                printPlayer(player,ref px,ref py);
            }
           
        }
        static void moveleft(char[,] player,ref int px,ref int py)
        {
           
            if (array[py,px-1]==' ' && array[py+1,px-1]==' ' && array[py+2,px-1]==' ')
            {
                gotoxy(px, py);
                removeplayer(ref px, ref py);
                px = px - 1;
                gotoxy(px, py);
                printPlayer(player,ref px,ref py);
            }
          
        }
        static void moveup(char[,] player,ref int px,ref int py)
        {
            
            if (array[py-1, px] == ' ' && array[py - 1, px + 1] == ' ' && array[py - 1, px + 2] == ' ')
            {
                gotoxy(px, py);
                removeplayer(ref px,ref py);
                py = py - 1;
                gotoxy(px, py);
                printPlayer(player,ref px,ref py);
            }
       
        }
        static void movedown(char[,] player,ref int px,ref int py)
        {
           
            if (array[py+4, px] == ' ' && array[py + 3, px + 1] == ' ' && array[py + 3, px + 2] == ' ')
            { 
                gotoxy(px, py);
                removeplayer(ref px, ref py);
                py = py + 1;
                gotoxy(px, py);
                printPlayer(player, ref px, ref py);
            }
        }
        static char getCharatxy(int x,int y)
        {
            Console.SetCursorPosition(x, y);
            return Console.ReadKey().KeyChar;
        }
        static void removeplayer(ref int px,ref int py)
        {
            gotoxy(px, py);
            Console.Write( "   ");
            gotoxy(px, py + 1);
            Console.Write("   ");
            gotoxy(px, py + 2);
            Console.Write("   ");
        }
        static void removeVerticalGhost(ref int vgx,ref int vgy)
        {
            gotoxy(vgx, vgy);
            Console.Write("   ");
            gotoxy(vgx, vgy + 1);
            Console.Write("   ");
            gotoxy(vgx, vgy + 2);
            Console.Write("   ");
        }
        static void moveVerticalGhost(char[,] verticalGhost,ref int vgx,ref int vgy)
        {
            if (direction == "down")
            {
               
                if (array[vgy + 3, vgx] == '%' || array[vgy + 3, vgy + 1] == '%' || array[vgy+3, vgx + 2] == '%' || array[vgy + 3, vgx] == '*' || array[vgy + 3, vgy + 1] == '*' || array[vgy + 3, vgx + 2] == '*')
                {
                    direction = "up";
                }
                else
                {
                    removeVerticalGhost(ref vgx,ref vgy);
                    vgy = vgy + 1;
                    printVerticalGhost(verticalGhost,ref vgx,ref vgy);
                }
            }
            if (direction == "up")
            {
               
                if ((array[vgy - 1, vgx] == '%' || array[vgy-1, vgx - 1] == '%' || array[vgy-1, vgx + 2] == '%') || (array[vgy - 1, vgx] == '*' || array[vgy - 1, vgx - 1] == '*' || array[vgy - 1, vgx + 2] == '*'))
                {
                    direction = "down";
                }
                else
                {
                    removeVerticalGhost(ref vgx,ref vgy);
                    vgy = vgy - 1;
                    printVerticalGhost(verticalGhost,ref vgx,ref vgy);
                }
            }
        }
        static void generateBullet(int[] bulletX, int[] bulletY, bool[] isBulletActive,ref int px,ref int py)
        {
            bulletX[bulletCount] = px + 3;
            bulletY[bulletCount] = py + 1;
            isBulletActive[bulletCount] = true;
            gotoxy(px + 3, py + 1);
            Console.Write( ">");
            bulletCount++;
        }
        static void generateBulletV(int[] bulletVX, int[] bulletVY, bool[] isBulletActiveVertical,ref int vgx,ref int vgy)
        {
            bulletVX[bulletCountV] = vgx - 1;
            bulletVY[bulletCountV] = vgy + 1;
            isBulletActiveVertical[bulletCountV] = true;
            gotoxy(vgx - 1, vgy + 1);
            Console.Write(".");
            bulletCountV++;
        }
        static void moveBulletV(int[] bulletVX, int[] bulletVY, bool[] isBulletActiveVertical)
        {
            char p =(char)148;
            for (int i = 0; i < bulletCountV; i++)
            {
                if (isBulletActiveVertical[i] == true)
                {
                   // char nextlocation = getCharatxy(bulletVX[i] - 1, bulletVY[i]);
                    //if (nextlocation == ' ')
                    if (array[bulletVY[i],bulletVX[i]-1]==' ')
                    {
                        eraseBulletV(bulletVX[i], bulletVY[i]);
                        bulletVX[i] = bulletVX[i] - 1;
                        printBulletV(bulletVX[i], bulletVY[i]);
                    }
                    else if (array[bulletVY[i], bulletVX[i] - 1] == '%')
                    {
                        eraseBulletV(bulletVX[i], bulletVY[i]);
                        makeBulletInactiveV(i, isBulletActiveVertical);
                        if (array[bulletVY[i], bulletVX[i] - 1] == p || array[bulletVY[i], bulletVX[i] - 1] == ')' || array[bulletVY[i], bulletVX[i] - 1] == '\\')
                        {
                            playerhealth--;
                        }
                    }

                }
            }
        }
        static void eraseBulletV(int x, int y)
        {
            gotoxy(x, y);
            Console.Write(" ");
        }
        static void printBulletV(int x, int y)
        {
            gotoxy(x, y);
            Console.Write(".");
        }
        static void makeBulletInactiveV(int i, bool[] isBulletActiveVertical)
        {
            isBulletActiveVertical[i] = false;
        }
        static void moveBullet(int[] bulletX, int[] bulletY, bool[] isBulletActive)
        {
            for (int i = 0; i < 1000; i++)
            {

                if (isBulletActive[i] == true)
                {
                   // char nextlocation = getCharatxy(bulletX[i] + 1, bulletY[i]);
                    if (array[bulletY[i],bulletX[i]+1] != ' ')
                    {
                        eraseBullet(bulletX[i], bulletY[i]);
                        makeBulletInactive(i, isBulletActive);
                        if (array[bulletY[i], bulletX[i] + 1] == '*')
                        {
                            Console.Write(" ");
                            addScore();
                        }
                    }
                    else
                    {
                        eraseBullet(bulletX[i], bulletY[i]);
                        bulletX[i] = bulletX[i] + 1;
                        printBullet(bulletX[i], bulletY[i]);
                    }
                }

            }
        }
        static void makeBulletInactive(int i, bool[] isBulletActive)
        {
            isBulletActive[i] = false;
        }
        static void printBullet(int x, int y)
        {
            gotoxy(x, y);
            Console.Write(">");
        }
        static void eraseBullet(int x, int y)
        {
            gotoxy(x, y);
            Console.Write( " ");
        }
        static void bulletCollisionWithVerticalEnemy(int[] bulletX, int[] bulletY, bool[] isBulletActive)
        {

            for (int i = 0; i < bulletCount; i++)
            {
               // char next = getCharatxy(bulletX[i] + 1, bulletY[i]);
                if (isBulletActive[i] == true)
                {
                    if (array[bulletY[i], bulletX[i] + 1] == '(' || array[bulletY[i], bulletX[i] + 1] == '@' || array[bulletY[i], bulletX[i] + 1] == '/')
                    {
                        addScore();
                        count--;
                        eraseBullet(bulletX[i], bulletY[i]);
                        isBulletActive[i] = false;
                    }
                }
            }
        }
    }
}
