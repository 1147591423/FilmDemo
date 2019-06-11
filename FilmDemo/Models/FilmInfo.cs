using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmDemo.Models
{
    public class FilmInfo
    {
        public int FId { get; set; }
        public string FilmCName { get; set; }
        public string FilmEName { get; set; }
        public string FilmType { get; set; }
        public string FilmSource { get; set; }
        public string FilmLength { get; set; }
        public DateTime FilmReleaseTime { get; set; }
        public int WantSee { get; set; }
        public float Grade { get; set; }
        public string FilmIntroduced { get; set; }
        public string FilmPhoto { get; set; }
    }
}