using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDemo.Models
{
    public class CinemaList
    {
        public int CId { get; set; }
        //影城名字
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
