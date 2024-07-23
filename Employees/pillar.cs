using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    internal class pillar
    {
        public pillar(
            int _whith,
            int _high,
            string _location)
        {
            Whith = _whith;
            High = _high;
            Location = _location;
        }
     public int Whith; { get; set; }
     public int High; { get; set; }
        public string Location; {  get; set; }
     public string getStatus(int whith,  int high, string location)
        {
            switch (location)
            {
                case "רשות הרבים":
                    if (Whith > 4)
                    {
                        if (High >= 10) { return "דין רשות היחיד"};
                        if (High <= 9 && High >= 3) { return "דין כרמלית"};
                    }
                    else
                    {
                        if (High <= 3) || (High >= 9 && <= 10) { return "דין רשות הרבים"};
                        if (high >= 9 && <= 3) || (high >= 10) { return "דין מקום פטור"};
                    }
                case "כרמלית":
                    if (whith > 4)
                    {
                        if (High > 10) { return "דין רשות היחיד"}
                        else { return "דין כרמלית"}
                case "רשות היחיד":
                    return;
                default:
                    return;
            }

    }
}
