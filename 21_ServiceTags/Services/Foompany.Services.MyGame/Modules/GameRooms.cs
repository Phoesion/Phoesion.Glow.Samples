using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.MyGame.Modules
{
    [API(typeof(API.MyGame.Modules.GameRooms.Actions))]
    public class GameRooms : FireflyModule
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------

        [Action(Methods.GET)]
        public string Default() => "GameRooms module up and running!";

        //----------------------------------------------------------------------------------------------------------------------------------------------

        [ActionBody(Methods.GET), InteropBody]
        public string CreateGameRoom(string RoomName)
        {
            return $"Created game room with name {RoomName}";
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
    }
}
