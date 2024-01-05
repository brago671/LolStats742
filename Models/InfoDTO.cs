using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LolStats742.Models
{
    /// <summary>
    /// Contains detailed game information.
    /// </summary>\
    public class InfoDTO
    {
        /// <summary>
        /// Gets or sets the game creation time in UTC. Designates when the team select lobby is created and/or the game is made through match making; not when the game actually starts.
        /// </summary>
        public long GameCreation { get; set; }

        /// <summary>
        /// Gets or sets the game duration.
        /// </summary>
        /// <remarks>
        /// The game duration is serialized as an integer representing the duration of the game in seconds.
        /// </remarks>
        public TimeSpan GameDuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public long GameEndTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the ID of the game.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long GameId { get; set; }

        /// <summary>
        /// Gets or sets the game mode. This should equal one of the <see cref="Models.GameMode"/> values.
        /// </summary>
        public string GameMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public long GameStartTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the game type. This should equal one of the <see cref="Models.GameType"/> values.
        /// </summary>
        public string GameType { get; set; }

        /// <summary>
        /// Gets or sets the game version (patch number).
        /// </summary>
        public string GameVersion { get; set; }

        /// <summary>
        /// Gets or sets the map ID of the map where the match was played.
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// Gets or sets the list of participants' information.
        /// </summary>
        public virtual List<MatchParticipant> Participants { get; set; }

        /// <summary>
        /// Gets or sets the platform ID of the match. This should equal one of the <see cref="Models.PlatformId"/> values.
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// Gets or sets the game queue type.
        /// </summary>
        public int QueueId { get; set; }

        /// <summary>
        /// Gets or sets team information.
        /// </summary>
        public virtual List<MatchTeam> Teams { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TournamentCode { get; set; }
    }
}
