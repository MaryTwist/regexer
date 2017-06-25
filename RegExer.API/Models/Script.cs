using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace RegExer.API.Models
{
    public class Script
    {
        public int ScriptId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SearchPattern { get; set; }
        public string ReplacePattern { get; set; }
        public DateTime Made { get; set; }
        public DateTime? Modified { get; set; }

        public Script()
        { }

        public Script(DataRow row)
        {
            ScriptId = row.Field<int>("ScriptId");
            Name = row.Field<string>("Name");
            Description = row.Field<string>("Description");
            SearchPattern = row.Field<string>("SearchPattern");
            ReplacePattern = row.Field<string>("ReplacePattern");
            Made = row.Field<DateTime>("Made");
            Modified = row.Field<DateTime?>("Modified");
        }
    }
}