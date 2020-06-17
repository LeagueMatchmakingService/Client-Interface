using Chromely.Core.Network;
using Newtonsoft.Json;
using ServerAppDemo.Models;
using ServerAppDemo.Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace ServerAppDemo.ChromelyControllers
{
    [ControllerProperty(Name = "MatchmakingController", Route = "matchmakingcontroller")]
    public class MatchmakingController : ChromelyController
    {

        public ILeagueClient League;
        public MatchmakingController()
        {
        }

        public async void CreateOneOnOneGame(string LobbyName, string Enemyid)
        {
            ILeagueClient league = await LeagueClient.Connect();
            ApiObject api = new ApiObject();
            var obj = api.createCustomGameOneOnOne(LobbyName);
            var response = await league.MakeApiRequest(HttpMethod.Post, "/lol-lobby/v2/lobby", obj);

            while (true)
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    obj = api.createCustomGameOneOnOne(LobbyName);
                    response = league.MakeApiRequest(HttpMethod.Post, "/lol-lobby/v2/lobby", obj).Result;
                }
                else
                {
                    break;
                }
            }

            var invites = new List<LobbyInvitation>();

            invites.Add(new LobbyInvitation
            {
                ToSummonerId = Enemyid
            });
            await league.MakeApiRequest(HttpMethod.Post, "/lol-lobby/v2/lobby/invitations", invites);
            bool AllIn = false;
            while (!AllIn)
            {
                LobbyPlayerInfo[] players = await league.MakeApiRequestAs<LobbyPlayerInfo[]>(HttpMethod.Get, "/lol-lobby/v2/lobby/members");
                foreach (var item in players)
                {
                    if (item.SummonerId == Enemyid)
                    {
                        AllIn = true;
                    }
                }
            }
            await league.MakeApiRequest(HttpMethod.Post, "/lol-lobby/v1/lobby/custom/start-champ-select", new StartGame());
        }

        public async void JoinGame(string enemy, Match match)
        {
            bool matchAccepted = false;
            ILeagueClient league = await LeagueClient.Connect();
            while (!matchAccepted)
            {
                var response = await league.MakeApiRequest(HttpMethod.Get, "/lol-lobby/v2/received-invitations");
                var invites = JsonConvert.DeserializeObject<List<InviteModel>>(await response.Content.ReadAsStringAsync());

                foreach (var item in invites)
                {
                    if (item.FromSummonerId == enemy)
                    {
                        await league.MakeApiRequest(HttpMethod.Post, "/lol-lobby/v2/received-invitations/" + item.InvitationId + "/accept");
                        System.Net.Http.HttpClient http = new System.Net.Http.HttpClient();
                        matchAccepted = true;
                    }
                }
                await Task.Delay(100);
            }
        }


    }


    }
