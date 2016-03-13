using System;
using System.Collections.Generic;
using System.Linq;

namespace FHL.Data.Models.NHL
{
    public sealed class PlayerSuggestions
    {
        private Lazy<ICollection<PlayerModel>> _playersLazy;

        private IList<string> _suggestions;

        public IList<string> suggestions
        {
            get { return this._suggestions; }
            set
            {
                this._suggestions = value;

                this._playersLazy = new Lazy<ICollection<PlayerModel>>(
                    () => this._suggestions.Any()
                        ? this._suggestions
                            .Select(PlayerModel.FromPlayerSuggestions)
                            .Where(p => p != null)                            
                            .ToArray()
                        : null);
            }
        }

        public ICollection<PlayerModel> Players
        {
            get { return this._playersLazy.Value; }
        }
    }
}