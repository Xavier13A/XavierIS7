﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using XavierIS7.Droid;

[assembly: Xamarin.Forms.Dependency(typeof (SqlCliente))]

namespace XavierIS7.Droid
{
    public class SqlCliente : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var DocumethPath= System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(DocumethPath, "uisrael.db3");


            return new SQLiteAsyncConnection(path);

        }
    }
}