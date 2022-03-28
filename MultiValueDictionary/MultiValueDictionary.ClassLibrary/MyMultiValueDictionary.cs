using MultiValueDictionary.ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionary.ClassLibrary
{
    public class MyMultiValueDictionary
    {
        private static MyMultiValueDictionary instance = null;
        public Dictionary<string, List<string>> dictionary; 

        private MyMultiValueDictionary()
        {
            dictionary = new Dictionary<string, List<string>>();
        }

        public static MyMultiValueDictionary Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyMultiValueDictionary();
                }

                return instance;
            }
        }

    }
}

       
