using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDemo.Models
{
    public class CinemaWithFilm
    {
        public int WId { get; set; }
        public int CId { get; set; }
        public int FId { get; set; }
        public DateTime ShowTime { get; set; }
        public string LanguageVersion { get; set; }
        public string Screens { get; set; }
        public decimal FilmPrice { get; set; }
        public string ShowBegin { get; set; }
        public string ShowEnd { get; set; }
        public string FilmCName { get; set; }
        public string FilmEName { get; set; }
        public string FilmType { get; set; }
        public string FilmSource { get; set; }
        public string FilmLength { get; set; }
        public DateTime FilmReleaseTime { get; set; }
        public int WantSee { get; set; }
        public float Grade { get; set; }
        public string FilmIntroduced { get; set; }
        public string FilmPhotos { get; set; }
        public float Filmoffice { get; set; }
        public string Lname { get; set; }
        //影城所在地址

        public string Laddress { get; set; }
        //链表ID

        public int Lpid { get; set; }
        //价钱
        public int Lfares { get; set; }
        //电话
        public string LPhone { get; set; }
        //影院图片
        public string LImg { get; set; }
    }
}
