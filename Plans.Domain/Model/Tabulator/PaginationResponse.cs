using System.Collections.Generic;
using Newtonsoft.Json;

namespace Plans.Domain.Model.Tabulator
{
    public class PaginationResponse<TIEntity>
    {
        [JsonProperty("last_page")]
        public int LastPage { get; set; }

        [JsonProperty("data")]
        public IList<TIEntity> Data { get; set; }
    }
}
