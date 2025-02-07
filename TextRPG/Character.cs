using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Character
    {
        string id = "jisungjjang";
        string name = "임지성킹왕짱";
        int lv = 1;
        int hp = 100;
        int mp = 50;
        /// <summary>
        /// 공격력
        /// </summary>
        int atk = 1;
        /// <summary>
        /// 방어력
        /// </summary>
        int def = 0;
        string cls = "궁수";
        int pwr = 1;
        int spd = 1;
        int mag = 0;
        int stm = 10;
        int exp = 0;
        /// <summary>
        /// 회피율
        /// </summary>
        int ev = 3;
        /// <summary>
        /// 명중(회피무시)
        /// </summary>
        int hit = 1;


    }
}
