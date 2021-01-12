using Oxide.Core.Libraries.Covalence;
using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("SetHome", "JazzDevs", "0.1")] //Info For The Plugin 
    class SetHome : CovalencePlugin
    {
        private Dictionary<string, GenericPosition> sethomes = new Dictionary<string, GenericPosition>(); //Makes The Array For The SetHomes Of The Player

        private void Init() //Gets Called When The Plugin Gets Initialized 
        {
            Puts("Home Set Plugin Initialized."); //Puts A Message In The Server Console
        }

        [Command("sethome")] // Registeres A SetHome Command
        private void SetHome(IPlayer player, string cmd, string[] args) //The Command Funciton
        {
            sethomes[player.Id] = player.Position(); //Adds The Players Current Position To The Array
            player.Reply("Your home has been set."); //Replys/Messages The Player That Thier Home Has Been Set.
        }

        [Command("home")] //Registers The Home Command
        private void Home(IPlayer player, string cmd, string[] args) // The Commands Function
        {
            if (!sethomes.ContainsKey(player.Id)) // If The Array Does Not Have A Position With That Players Specific PlayerID Then It Does The Stuff Below
            {
                player.Reply("You do not have a home set right now."); //Tells The Player That They Do Not Have A Set Home And Indicates To Make One 
                return; //End The Function There 
            }

            player.Teleport(sethomes[player.Id]); // If The If Statement Above Doesnt Happen Then Do This / Teleports The Player To Their Saved Home Location 
            player.Reply("Sending you home!"); // Send The Player A Message Telling Them That They Have Succefully Telported Using The Said Command
        }
    }
}