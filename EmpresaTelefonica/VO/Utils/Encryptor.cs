﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VO.Utils
{
    public class Encryptor
    {
        public static string HashPassword(string Password)
        {

            MD5CryptoServiceProvider MD5Code = new MD5CryptoServiceProvider();
            byte[] byteDizisi = Encoding.UTF8.GetBytes(Password);
            byteDizisi = MD5Code.ComputeHash(byteDizisi);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in byteDizisi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            SHA1CryptoServiceProvider SHA1Code = new SHA1CryptoServiceProvider();
            byteDizisi = Encoding.UTF8.GetBytes(sb.ToString());
            byteDizisi = SHA1Code.ComputeHash(byteDizisi);
            sb = new StringBuilder();
            foreach (byte ba in byteDizisi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            return sb.ToString();
        }
    }
}
