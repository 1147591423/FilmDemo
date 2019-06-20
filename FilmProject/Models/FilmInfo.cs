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
        public string FilmPhotos { get; set; }
        public int AId { get; set; }//主键
        public string ActorCName { get; set; }//演员中文名
        public string ActorEName { get; set; }//演员英文名
        public DateTime ActorBirthday { get; set; }//演员生日
        public string ActorRemark { get; set; }//演员介绍
        public string ActorBirthPlace { get; set; }//演员出生地
        public int ActorSex { get; set; }//演员性别
        public string ActorNationality { get; set; }//演员国籍
        public string ActorPhotos { get; set; }//演员照片

    }
}