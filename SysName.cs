﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExcel
{
    public class SysName
    {
        public SysName() { }
        public string NameToSys(int i)
        {
            int k = 0;
            int[] Arr = new int[100];
            while (i > 25)
            {
                Arr[k] = i / 26 - 1;
                k++;
                i = i % 26;
            }
            Arr[k] = i;
            string res = "";
            for(int j = 0; j <= k; j++)
            {
                res = res + ((char)('A' + Arr[j])).ToString();
            }
            return res;
        }

        public int NameFromSys(string ColumnName)
        {
            char[] chArray = ColumnName.ToCharArray();
            int l = chArray.Length;
            int res = 0;
            for(int i = l - 2; i >= 0; i++)
            {
                res = res + ((int)chArray[i] - (int)'A' + 1) * Convert.ToInt32(Math.Pow(26, l - i - 1));
            }
            res = res + ((int)chArray[l - 1] - (int)'A');
            return res;
        }
    }
}
