﻿using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API;
using CSPracc.DataModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSPracc
{
    public class Utils
    {

        /// <summary>
        /// detects input for aliases and replaces them
        /// </summary>
        /// <param name="alias">input</param>
        /// <returns>returns string with full command</returns>
        public static string ReplaceAlias(string alias)
        {
            string ShortCommand = alias;
            string LongCommand = alias;
            bool aliasFound = false;
            do
            {
                aliasFound = false;
                foreach (CommandAlias calias in CSPraccPlugin.Config!.CommandAliases)
                {
                    if (calias.Alias == ShortCommand)
                    {
                        ShortCommand = calias.Command;
                        aliasFound = true;
                    }
                }
            } while (aliasFound);
            LongCommand = ShortCommand;
            return LongCommand;
        }

        /// <summary>
        /// Deleting Grenades from server
        /// </summary>
        public static void RemoveGrenadeEntities()
        {
            var smokes = Utilities.FindAllEntitiesByDesignerName<CSmokeGrenadeProjectile>("smokegrenade_projectile");
            foreach (var entity in smokes)
            {
                if (entity != null)
                {
                    entity.Remove();
                }
            }
            var mollys = Utilities.FindAllEntitiesByDesignerName<CSmokeGrenadeProjectile>("molotov_projectile");
            foreach (var entity in mollys)
            {
                if (entity != null)
                {
                    entity.Remove();
                }
            }
            var inferno = Utilities.FindAllEntitiesByDesignerName<CSmokeGrenadeProjectile>("inferno");
            foreach (var entity in inferno)
            {
                if (entity != null)
                {
                    entity.Remove();
                }
            }
        }

        public static Color GetTeamColor(CCSPlayerController playerController)
        {
            Logging.LogMessage($"Getting Color of player {playerController.CompTeammateColor}");
            switch (playerController.CompTeammateColor)
            {
                case 1:
                    return Color.FromArgb(50, 255, 0);
                case 2:
                    return Color.FromArgb(255, 255, 0);
                case 3:
                    return Color.FromArgb(255, 132, 0);
                case 4:
                    return Color.FromArgb(255, 0, 255);
                case 0:
                    return Color.FromArgb(0, 187, 255);
                default:
                    return Color.Red;
            }
        }
    }
}